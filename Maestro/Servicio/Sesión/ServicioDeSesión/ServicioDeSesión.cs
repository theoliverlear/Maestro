using Microsoft.IdentityModel.Tokens;

namespace Maestro.Servicio.Sesión.ServicioDeSesión;

public class ServicioDeSesión : IServicioDeSesión
{
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
        if (!this.ExistePorClave("UsuarioId"))
        {
            return false;
        }
        sesión.Remove("UsuarioId");
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
}