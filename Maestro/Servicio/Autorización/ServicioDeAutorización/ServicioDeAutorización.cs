using Maestro.Comunicación.Respuesta.Autorización;
using Maestro.Comunicación.Solicitud.Autorización;

namespace Maestro.Servicio.Autorización.ServicioDeAutorización;

public class ServicioDeAutorización : IServicioDeAutorización
{
    public RespuestaDeEstadoDeAutorización Acceso(SolicitudInicioDeSesión solicitud)
    {
        throw new NotImplementedException();
    }

    public RespuestaDeEstadoDeAutorización Registro(SolicitudDeRegistro solicitud)
    {
        throw new NotImplementedException();
    }
}