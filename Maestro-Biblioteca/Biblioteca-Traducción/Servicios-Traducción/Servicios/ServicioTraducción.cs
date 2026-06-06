using Google.Cloud.Translation.V2;
using Maestro.Biblioteca.Traducción.Comunicación.Respuesta;
using Maestro.Biblioteca.Traducción.Comunicación.Solicitud;
using Maestro.Biblioteca.Traducción.Modelos;
using Microsoft.Extensions.Configuration;

namespace Maestro.Biblioteca.Traducción.Servicios;

public class ServicioTraducción : IServicioTraducción
{
    private readonly IConfiguration _configuración;

    public ServicioTraducción(IConfiguration configuración)
    {
        this._configuración = configuración;
    }

    public Task<RespuestaTraducción> ProcesarAsync(SolicitudTraducción solicitud,
                                                   string? encabezadoDeAutorizacion,
                                                   CancellationToken ct = default)
    {
        LenguajeTraducible lenguajeDeDestino = ObtenerLenguajeDeDestino(solicitud.LenguajeDeOrigen);
        TranslationClient cliente = this.CrearCliente();
        TranslationResult resultado = cliente.TranslateText(
            solicitud.Texto,
            ObtenerCódigoDeLenguaje(lenguajeDeDestino),
            ObtenerCódigoDeLenguaje(solicitud.LenguajeDeOrigen));
        RespuestaTraducción respuesta = new(resultado.TranslatedText);
        return Task.FromResult(respuesta);
    }

    private static LenguajeTraducible ObtenerLenguajeDeDestino(LenguajeTraducible lenguajeDeOrigen)
    {
        return lenguajeDeOrigen switch
        {
            LenguajeTraducible.Español => LenguajeTraducible.Inglés,
            LenguajeTraducible.Inglés => LenguajeTraducible.Español,
            _ => throw new ArgumentOutOfRangeException(nameof(lenguajeDeOrigen), lenguajeDeOrigen, null)
        };
    }

    private TranslationClient CrearCliente()
    {
        string? claveApi = this._configuración["Google:TranslationApiKey"] ??
                           this._configuración["GOOGLE_TRANSLATION_API_KEY"];
        return string.IsNullOrWhiteSpace(claveApi)
            ? TranslationClient.Create()
            : TranslationClient.CreateFromApiKey(claveApi, TranslationModel.ServiceDefault);
    }

    private static string ObtenerCódigoDeLenguaje(LenguajeTraducible lenguaje)
    {
        return lenguaje switch
        {
            LenguajeTraducible.Español => "es",
            LenguajeTraducible.Inglés => "en",
            _ => throw new ArgumentOutOfRangeException(nameof(lenguaje), lenguaje, null)
        };
    }
}
