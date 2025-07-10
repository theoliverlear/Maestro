using Maestro.Comunicación.Respuesta.Autorización;
using Maestro.Comunicación.Solicitud.Autorización;
using Maestro.Servicio.Sesión.ServicioDeSesión;
using Maestro.Servicio.Usuarios.ServicioDeUsuario;

namespace Maestro.Servicio.Autorización.ServicioDeAutorización;

public class ServicioDeAutorización : IServicioDeAutorización
{
    private readonly IServicioDeSesión _servicioDeSesión;
    private readonly IServicioDeUsuario _servicioDeUsuario;
    public ServicioDeAutorización(IServicioDeSesión servicioDeSesión,
                                  IServicioDeUsuario servicioDeUsuario)
    {
        this._servicioDeSesión = servicioDeSesión;
        this._servicioDeUsuario = servicioDeUsuario;
    }

    public RespuestaDeEstadoDeAutorización Acceso(SolicitudInicioDeSesión solicitud)
    {
        throw new NotImplementedException();
    }

    public RespuestaDeEstadoDeAutorización Registro(SolicitudDeRegistro solicitud)
    {
        throw new NotImplementedException();
    }
}