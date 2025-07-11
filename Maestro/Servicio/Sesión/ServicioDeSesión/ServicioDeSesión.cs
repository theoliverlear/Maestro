using Microsoft.IdentityModel.Tokens;

namespace Maestro.Servicio.Sesión.ServicioDeSesión;

public class ServicioDeSesión : IServicioDeSesión
{
    private static readonly string ClaveDeIdDeUsuario = "UsuarioId";
    private readonly IHttpContextAccessor _contextoHttp;
    private readonly ILogger<ServicioDeSesión> _log;
    public ServicioDeSesión(IHttpContextAccessor contextoHttp,
                            ILogger<ServicioDeSesión> log)
    {
        this._contextoHttp = contextoHttp;
        this._log = log;
    }

    public bool EsUnaSesiónVálida(HttpContext? contextoHttp, ISession? sesión)
    {
        return !(contextoHttp == null || sesión == null);
    }

    public ISession ObtenerSesión()
    {
        HttpContext? contextoHttp = this._contextoHttp.HttpContext;
        ISession? sesión = this._contextoHttp.HttpContext?.Session;
        if (!this.EsUnaSesiónVálida(contextoHttp, sesión))
        {
            this._log.LogError("No se pudo obtener la sesión HTTP. Contexto o sesión es nulo.");
            throw new InvalidOperationException("No hay una sesión activa.");
        }
        return this._contextoHttp.HttpContext!.Session;
    }

    public bool AsignarIdDeUsuario(int id)
    {
        ISession sesión = this.ObtenerSesión();
        if (id <= 0)
        {
            throw new ArgumentException("El ID de usuario debe ser un valor positivo.", nameof(id));
        }
        this._log.LogInformation("Asignando ID de usuario {UsuarioId} a la sesión.", id);
        sesión.SetInt32("UsuarioId", id);
        return true;
    }

    public bool EliminarIdDeUsuario()
    {
        ISession sesión = this.ObtenerSesión();
        this._log.LogInformation("Eliminando ID de usuario de la sesión.");
        if (!this.ExistePorClave(ClaveDeIdDeUsuario))
        {
            return false;
        }
        sesión.Remove(ClaveDeIdDeUsuario);
        return true;
    }

    public bool ExistePorClave(string clave)
    {
        if (clave.IsNullOrEmpty())
        {
            return false;
        }
        ISession sesión = this.ObtenerSesión();
        return sesión.Keys.Contains(clave);
    }



    public bool UsuarioEnSesión()
    {
        ISession sesión = this.ObtenerSesión();
        if (!this.ExistePorClave(ClaveDeIdDeUsuario))
        {
            this._log.LogWarning("No hay un ID de usuario en la sesión.");
            return false;
        }
        int? idUsuario = sesión.GetInt32(ClaveDeIdDeUsuario);
        if (idUsuario is null or <= 0)
        {
            this._log.LogWarning("El ID de usuario en la sesión es nulo o no válido.");
            return false;
        }
        this._log.LogInformation("El ID de usuario {UsuarioId} está en la sesión.", idUsuario);
        return true;
    }

    public int? ObtenerIdDelUsuarioDeSesión()
    {
        if (!this.UsuarioEnSesión())
        {
            this._log.LogWarning("No hay un usuario en la sesión.");
            return null;
        }
        ISession sesión = this.ObtenerSesión();
        int? idUsuario = sesión.GetInt32(ClaveDeIdDeUsuario);
        if (idUsuario is null or <= 0)
        {
            this._log.LogWarning("El ID de usuario en la sesión es nulo o no válido.");
            return null;
        }
        this._log.LogInformation("Obteniendo ID de usuario {UsuarioId} de la sesión.", idUsuario);
        return idUsuario;
    }
}