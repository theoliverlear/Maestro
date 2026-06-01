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
            return new(EstadoDeAutorización.Autoizado.EsAutorizado);
        }
        Usuario? usuario = this._servicioDeUsuario.ObtenerPorCorreoElectrónico(solicitud.CorreoElectrónico);
        if (usuario == null)
        {
            return new(EstadoDeAutorización.NoAutorizado.EsAutorizado);
        }
        bool contraseñasCoinciden = usuario.ContraseñaSegura.CoincidenciasCodificadas(solicitud.Contraseña);
        EstadoDeAutorización estadoDeAutorización = EstadoDeAutorización.DelEstadoDeContraseña(contraseñasCoinciden);
        return new(estadoDeAutorización.EsAutorizado);
    }

    public async Task<RespuestaDeEstadoDeAutorización> Registro(SolicitudDeRegistro solicitud)
    {
        if (this._servicioDeSesión.UsuarioEnSesión())
        {
            return new(EstadoDeAutorización.Autoizado.EsAutorizado);
        }
        Usuario? usuarioExistente = this._servicioDeUsuario.ObtenerPorCorreoElectrónico(solicitud.CorreoElectrónico);
        if (usuarioExistente != null)
        {
            return new(EstadoDeAutorización.NoAutorizado.EsAutorizado);
        }

        Usuario nuevoUsuario = Usuario.Constructor()
                                      .ConContraseñaSegura(solicitud.Contraseña)
                                      .ConCorreoElectrónico(solicitud.CorreoElectrónico)
                                      .Construir();
        await this._servicioDeUsuario.AgregarAsíncrono(nuevoUsuario);
        return new(EstadoDeAutorización.Autoizado.EsAutorizado);
    }

    public RespuestaDeEstadoDeAutorización Conectado()
    {
        if (this._servicioDeSesión.UsuarioEnSesión())
        {
            return new(EstadoDeAutorización.Autoizado.EsAutorizado);
        }
        return new(EstadoDeAutorización.NoAutorizado.EsAutorizado);
    }
}
