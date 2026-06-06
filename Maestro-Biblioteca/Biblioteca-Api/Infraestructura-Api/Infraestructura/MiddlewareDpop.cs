using Maestro.Biblioteca.Api.Servicio.Autorización.ServicioDpop;
using Microsoft.Extensions.Primitives;
using Maestro.Biblioteca.Api.Modelos.Autorización.Dpop;
using Microsoft.AspNetCore.Http;

namespace Maestro.Biblioteca.Api.Infraestructura;

public class MiddlewareDpop
{
    private readonly RequestDelegate _siguiente;

    public MiddlewareDpop(RequestDelegate siguiente)
    {
        this._siguiente = siguiente;
    }

    public async Task InvokeAsync(HttpContext contexto,
                                  IServicioDeVerificaciónDpop servicioDeVerificaciónDpop)
    {
        string? autorización = contexto.Request.Headers.Authorization.FirstOrDefault();
        string? tokenDeAcceso = this.ExtraerTokenDeAcceso(autorización);
        bool requiereDpop = this.RutaRequiereDpop(contexto.Request.Path) ||
                            this.EsAutorizaciónDpop(autorización);
        if (!requiereDpop)
        {
            await this._siguiente(contexto);
            return;
        }

        StringValues prueba = contexto.Request.Headers["DPoP"];
        string url = this.ObtenerUrlCompleta(contexto.Request);
        ResultadoDeVerificaciónDpop resultado = servicioDeVerificaciónDpop.VerificarConResultado(
            prueba.FirstOrDefault(),
            contexto.Request.Method,
            url,
            tokenDeAcceso);

        if (!resultado.EsVálido)
        {
            contexto.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await contexto.Response.WriteAsJsonAsync(new
            {
                esAutorizado = false,
                razón = resultado.Razón
            });
            return;
        }

        contexto.Items["dpop.prueba"] = resultado.Contexto;
        await this._siguiente(contexto);
    }

    private bool RutaRequiereDpop(PathString ruta)
    {
        // TODO: Reemplazar con anotación.
        return ruta.StartsWithSegments("/api/autorización/acceso") ||
               ruta.StartsWithSegments("/api/autorización/registro") ||
               ruta.StartsWithSegments("/api/autorización/actualizar");
    }

    private bool EsAutorizaciónDpop(string? autorización)
    {
        return autorización?.StartsWith("DPoP ", StringComparison.OrdinalIgnoreCase) == true;
    }

    private string? ExtraerTokenDeAcceso(string? autorización)
    {
        return this.EsAutorizaciónDpop(autorización)
            ? autorización!["DPoP ".Length..].Trim()
            : null;
    }

    private string ObtenerUrlCompleta(HttpRequest solicitud)
    {
        return $"{solicitud.Scheme}://{solicitud.Host}{solicitud.PathBase}{solicitud.Path}{solicitud.QueryString}";
    }
}
