namespace Maestro.Servicio.Sesión.ServicioDeSesión;

public interface IServicioDeSesión
{
    bool EsUnaSesiónVálida(HttpContext? contextoHttp, ISession? sesión);
    ISession ObtenerSesión();
    bool AsignarIdDeUsuario(int id);
    bool EliminarIdDeUsuario();
    bool ExistePorClave(string clave);
    bool UsuarioEnSesión();
    int? ObtenerIdDelUsuarioDeSesión();
}