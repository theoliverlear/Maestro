namespace Maestro.Servicio.Autorización.ServicioDpop;

public interface IAlmacénDeReproducciónDpop
{
    bool FueReproducido(string? idDeJwt);
    void Recordar(string? idDeJwt);
}
