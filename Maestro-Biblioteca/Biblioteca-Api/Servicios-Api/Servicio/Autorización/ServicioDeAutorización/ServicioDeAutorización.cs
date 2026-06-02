using Maestro.Comunicación.Respuesta.Autorización;
using Maestro.Comunicación.Solicitud.Autorización;
using Maestro.Entidad.Usuario;
using Maestro.Modelos.Autorización;
using Maestro.Modelos.Autorización.Dpop;
using Maestro.Entidad.Autorización;
using Maestro.Servicio.Autorización.ServicioDeTokenDeActualización;
using Maestro.Servicio.Autorización.ServicioDeTokenJwt;
using Maestro.Servicio.Sesión.ServicioDeSesión;
using Maestro.Servicio.Usuarios.ServicioDeUsuario;
using Microsoft.AspNetCore.Http;

namespace Maestro.Servicio.Autorización.ServicioDeAutorización;

public class ServicioDeAutorización : IServicioDeAutorización
{
    private readonly IServicioDeSesión _servicioDeSesión;
    private readonly IServicioDeUsuario _servicioDeUsuario;
    private readonly IServicioDeTokenJwt _servicioDeTokenJwt;
    private readonly IServicioDeTokenDeActualización _servicioDeTokenDeActualización;
    private readonly IHttpContextAccessor _contextoHttp;
    public ServicioDeAutorización(IServicioDeSesión servicioDeSesión,
                                  IServicioDeUsuario servicioDeUsuario,
                                  IServicioDeTokenJwt servicioDeTokenJwt,
                                  IServicioDeTokenDeActualización servicioDeTokenDeActualización,
                                  IHttpContextAccessor contextoHttp)
    {
        this._servicioDeSesión = servicioDeSesión;
        this._servicioDeUsuario = servicioDeUsuario;
        this._servicioDeTokenJwt = servicioDeTokenJwt;
        this._servicioDeTokenDeActualización = servicioDeTokenDeActualización;
        this._contextoHttp = contextoHttp;
    }

    public async Task<RespuestaDeEstadoDeAutorización> Acceso(SolicitudInicioDeSesión solicitud)
    {
        if (this._servicioDeSesión.UsuarioEnSesión())
        {
            return await this.CrearRespuestaParaUsuarioEnSesión();
        }
        Usuario? usuario = this._servicioDeUsuario.ObtenerPorCorreoElectrónico(solicitud.CorreoElectrónico);
        if (usuario == null)
        {
            return new(EstadoDeAutorización.NoAutorizado.EsAutorizado);
        }
        bool contraseñasCoinciden = usuario.ContraseñaSegura.CoincidenciasCodificadas(solicitud.Contraseña);
        EstadoDeAutorización estadoDeAutorización = EstadoDeAutorización.DelEstadoDeContraseña(contraseñasCoinciden);
        if (!estadoDeAutorización.EsAutorizado)
        {
            return new(false);
        }

        this._servicioDeSesión.AsignarIdDeUsuario(usuario.Id);
        return await this.CrearRespuestaAutorizada(usuario);
    }

    public async Task<RespuestaDeEstadoDeAutorización> Registro(SolicitudDeRegistro solicitud)
    {
        if (this._servicioDeSesión.UsuarioEnSesión())
        {
            return await this.CrearRespuestaParaUsuarioEnSesión();
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
        Usuario usuarioGuardado = await this._servicioDeUsuario.AgregarAsíncrono(nuevoUsuario);
        this._servicioDeSesión.AsignarIdDeUsuario(usuarioGuardado.Id);
        return await this.CrearRespuestaAutorizada(usuarioGuardado);
    }

    public RespuestaDeEstadoDeAutorización Conectado()
    {
        if (this._servicioDeSesión.UsuarioEnSesión() ||
            this._contextoHttp.HttpContext?.User.Identity?.IsAuthenticated == true)
        {
            return new(EstadoDeAutorización.Autoizado.EsAutorizado);
        }
        return new(EstadoDeAutorización.NoAutorizado.EsAutorizado);
    }

    public async Task<RespuestaDeEstadoDeAutorización> Actualizar(string idDeToken)
    {
        TokenDeActualización? tokenActualizado =
            await this._servicioDeTokenDeActualización.Rotar(idDeToken, this.ObtenerHuellaDpop());
        if (tokenActualizado == null)
        {
            return new(false);
        }

        Usuario? usuario = this._servicioDeUsuario.ObtenerPorId(tokenActualizado.IdUsuario);
        if (usuario == null)
        {
            return new(false);
        }

        string? huellaDpop = this.ObtenerHuellaDpop();
        string tokenJwt = this._servicioDeTokenJwt.Generar(usuario, huellaDpop);
        return new(true, tokenJwt, tokenActualizado.IdDeToken, tokenActualizado.ExpiraEn);
    }

    public async Task<RespuestaDeEstadoDeAutorización> Salir(string idDeToken)
    {
        await this._servicioDeTokenDeActualización.Revocar(idDeToken);
        this._servicioDeSesión.EliminarIdDeUsuario();
        return new(false);
    }

    private async Task<RespuestaDeEstadoDeAutorización> CrearRespuestaAutorizada(Usuario usuario)
    {
        string? huellaDpop = this.ObtenerHuellaDpop();
        string tokenJwt = this._servicioDeTokenJwt.Generar(usuario, huellaDpop);
        TokenDeActualización tokenDeActualización =
            await this._servicioDeTokenDeActualización.Emitir(usuario.Id, huellaDpop);
        return new(true, tokenJwt, tokenDeActualización.IdDeToken, tokenDeActualización.ExpiraEn);
    }

    private async Task<RespuestaDeEstadoDeAutorización> CrearRespuestaParaUsuarioEnSesión()
    {
        int? idUsuario = this._servicioDeSesión.ObtenerIdDelUsuarioDeSesión();
        if (idUsuario == null)
        {
            return new(EstadoDeAutorización.Autoizado.EsAutorizado);
        }

        Usuario? usuario = this._servicioDeUsuario.ObtenerPorId(idUsuario.Value);
        return usuario == null
            ? new(EstadoDeAutorización.Autoizado.EsAutorizado)
            : await this.CrearRespuestaAutorizada(usuario);
    }

    private string? ObtenerHuellaDpop()
    {
        return this._contextoHttp.HttpContext?.Items["dpop.prueba"] is ContextoDePruebaDpop contexto
            ? contexto.HuellaDeClave
            : null;
    }
}
