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

    public async Task<RespuestaDeEstadoDeAutorización> Registro(SolicitudDeRegistro solicitud)
    {
        if (this._servicioDeSesión.UsuarioEnSesión())
        {
            return new(EstadoDeAutorización.Autoizado);
        }
        Usuario? usuarioExistente = this._servicioDeUsuario.ObtenerPorNombreDeUsuario(solicitud.NombreDeUsuario);
        if (usuarioExistente != null)
        {
            return new(EstadoDeAutorización.NoAutorizado);
        }

        Usuario nuevoUsuario = Usuario.Constructor()
                                      .ConNombreDeUsuario(solicitud.NombreDeUsuario)
                                      .ConContraseñaSegura(solicitud.Contraseña)
                                      .ConCorreoElectrónico(solicitud.CorreoElectrónico)
                                      .Construir();
        await this._servicioDeUsuario.AgregarAsíncrono(nuevoUsuario);
        return new(EstadoDeAutorización.Autoizado);
    }

    public RespuestaDeEstadoDeAutorización Conectado()
    {
        if (this._servicioDeSesión.UsuarioEnSesión())
        {
            return new(EstadoDeAutorización.Autoizado);
        }
        return new(EstadoDeAutorización.NoAutorizado);
    }
}