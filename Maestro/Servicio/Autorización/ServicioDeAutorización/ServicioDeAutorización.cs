using Maestro.Comunicación.Respuesta.Autorización;
using Maestro.Comunicación.Solicitud.Autorización;
using Maestro.Entidad.Usuario;
using Maestro.Modelos.Autorización;
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
        if (this._servicioDeSesión.UsuarioEnSesión())
        {
            return new(EstadoDeAutorización.Autoizado);
        }
        Usuario? usuario = this._servicioDeUsuario.ObtenerPorNombreDeUsuario(solicitud.NombreDeUsuario);
        if (usuario == null)
        {
            return new(EstadoDeAutorización.NoAutorizado);
        }
        bool contraseñasCoinciden = usuario.ContraseñaSegura.CoincidenciasCodificadas(solicitud.Contraseña);
        EstadoDeAutorización estadoDeAutorización = EstadoDeAutorización.DelEstadoDeContraseña(contraseñasCoinciden);
        return new(estadoDeAutorización);
    }

    public RespuestaDeEstadoDeAutorización Registro(SolicitudDeRegistro solicitud)
    {
        throw new NotImplementedException();
    }
}