using System.Security.Cryptography;
using System.Text;
using Maestro.Biblioteca.Api.Modelos.Autorización.Dpop;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Maestro.Biblioteca.Api.Servicio.Autorización.ServicioDpop;

public class ServicioDeVerificaciónDpop : IServicioDeVerificaciónDpop
{
    private static readonly HashSet<string> AlgoritmosPermitidos = ["ES256"];
    private readonly IAlmacénDeReproducciónDpop _almacénDeReproducción;

    public ServicioDeVerificaciónDpop(IAlmacénDeReproducciónDpop almacénDeReproducción)
    {
        this._almacénDeReproducción = almacénDeReproducción;
    }

    public ContextoDePruebaDpop? Verificar(string? prueba,
                                           string método,
                                           string url,
                                           string? tokenDeAcceso = null)
    {
        return this.VerificarConResultado(prueba, método, url, tokenDeAcceso).Contexto;
    }

    public ResultadoDeVerificaciónDpop VerificarConResultado(string? prueba,
                                                             string método,
                                                             string url,
                                                             string? tokenDeAcceso = null)
    {
        if (string.IsNullOrWhiteSpace(prueba))
        {
            return new(null, "Falta la cabecera DPoP.");
        }

        try
        {
            if (!this.CabeceraEsVálida(prueba, out JsonWebKey? clavePública, out string? razónDeCabecera))
            {
                return new(null, razónDeCabecera);
            }
            JObject cuerpo = this.ObtenerCuerpo(prueba);

            TokenValidationParameters parámetros = new()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = clavePública,
                ValidAlgorithms = AlgoritmosPermitidos
            };
            JsonWebTokenHandler manejador = new();
            TokenValidationResult resultado = manejador.ValidateToken(prueba, parámetros);
            if (!resultado.IsValid)
            {
                return new(null, $"Firma DPoP no válida: {resultado.Exception?.GetType().Name}");
            }

            string? métodoDePrueba = cuerpo.Value<string>("htm");
            string? urlDePrueba = cuerpo.Value<string>("htu");
            string? idDeJwt = cuerpo.Value<string>("jti");
            string? emitidoEn = cuerpo.Value<string>("iat");
            if (!this.ReclamosSonVálidos(métodoDePrueba,
                    urlDePrueba,
                    emitidoEn,
                    método,
                    url))
            {
                return new(null,
                    $"Reclamos DPoP no válidos. htm={métodoDePrueba}; esperado={método}; htu={urlDePrueba}; esperado={url}; iat={emitidoEn}");
            }

            if (this._almacénDeReproducción.FueReproducido(idDeJwt))
            {
                return new(null, $"Prueba DPoP reproducida. jti={idDeJwt}");
            }

            string? hashDeToken = cuerpo.Value<string>("ath");
            if (tokenDeAcceso != null && hashDeToken != this.CrearHashDeToken(tokenDeAcceso))
            {
                return new(null, "El reclamo ath no coincide con el token de acceso.");
            }

            this._almacénDeReproducción.Recordar(idDeJwt);
            return new(new(this.CalcularHuella(clavePública!), idDeJwt, método, url), null);
        }
        catch (Exception ex)
        {
            // TODO: Eliminar rastro de la pila con un mensaje.
            return new(null, $"{ex.GetType().Name}: {ex.Message}");
        }
    }

    private bool CabeceraEsVálida(string prueba, out JsonWebKey? clavePública, out string? razón)
    {
        clavePública = null;
        razón = null;

        string[] partes = prueba.Split('.');
        if (partes.Length < 2)
        {
            razón = "JWT DPoP mal formado.";
            return false;
        }

        JObject cabecera = JObject.Parse(Encoding.UTF8.GetString(Base64UrlEncoder.DecodeBytes(partes[0])));
        string? algoritmo = cabecera.Value<string>("alg");
        string? tipo = cabecera.Value<string>("typ");
        if (!AlgoritmosPermitidos.Contains(algoritmo ?? string.Empty) ||
            !string.Equals(tipo, "dpop+jwt", StringComparison.OrdinalIgnoreCase))
        {
            razón = $"Cabecera DPoP no válida. alg={algoritmo}; typ={tipo}";
            return false;
        }

        JToken? jwk = cabecera["jwk"];
        if (jwk == null)
        {
            razón = "Cabecera DPoP no válida. Falta jwk.";
            return false;
        }

        clavePública = new JsonWebKey(jwk.ToString(Formatting.None));
        if (!string.IsNullOrWhiteSpace(clavePública.Kty))
        {
            return true;
        }

        razón = "Cabecera DPoP no válida. jwk no contiene kty.";
        return false;
    }

    private JObject ObtenerCuerpo(string prueba)
    {
        string[] partes = prueba.Split('.');
        if (partes.Length < 2)
        {
            throw new ArgumentException("JWT DPoP mal formado.");
        }

        return JObject.Parse(Encoding.UTF8.GetString(Base64UrlEncoder.DecodeBytes(partes[1])));
    }

    private bool ReclamosSonVálidos(string? métodoDePrueba,
                                    string? urlDePrueba,
                                    string? emitidoEn,
                                    string método,
                                    string url)
    {
        if (!string.Equals(métodoDePrueba, método, StringComparison.OrdinalIgnoreCase) ||
            !string.Equals(NormalizarUrl(urlDePrueba), NormalizarUrl(url), StringComparison.Ordinal))
        {
            return false;
        }

        if (!long.TryParse(emitidoEn, out long segundos))
        {
            return false;
        }

        DateTimeOffset momento = DateTimeOffset.FromUnixTimeSeconds(segundos);
        TimeSpan diferencia = (DateTimeOffset.UtcNow - momento).Duration();
        return diferencia <= TimeSpan.FromSeconds(30);
    }

    private string CalcularHuella(JsonWebKey clave)
    {
        JObject objeto = clave.Kty switch
        {
            "EC" => new JObject
            {
                ["crv"] = clave.Crv,
                ["kty"] = "EC",
                ["x"] = clave.X,
                ["y"] = clave.Y
            },
            "RSA" => new JObject
            {
                ["e"] = clave.E,
                ["kty"] = "RSA",
                ["n"] = clave.N
            },
            _ => throw new NotSupportedException("Tipo de clave DPoP no admitido.")
        };
        string jsonCanónico = JsonConvert.SerializeObject(objeto, Formatting.None);
        byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(jsonCanónico));
        return Base64UrlEncoder.Encode(hash);
    }

    private string CrearHashDeToken(string tokenDeAcceso)
    {
        byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(tokenDeAcceso));
        return Base64UrlEncoder.Encode(hash);
    }

    private static string? NormalizarUrl(string? url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            return null;
        }

        Uri uri = new(url);
        UriBuilder constructor = new(uri)
        {
            Scheme = uri.Scheme.ToLowerInvariant(),
            Host = uri.Host.ToLowerInvariant()
        };
        if ((constructor.Scheme == "http" && constructor.Port == 80) ||
            (constructor.Scheme == "https" && constructor.Port == 443))
        {
            constructor.Port = -1;
        }

        return constructor.Uri.ToString();
    }
}
