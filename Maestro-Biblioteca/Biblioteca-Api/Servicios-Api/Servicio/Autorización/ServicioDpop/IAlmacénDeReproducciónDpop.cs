namespace Maestro.Biblioteca.Api.Servicio.Autorización.ServicioDpop;

public interface IAlmacénDeReproducciónDpop
{
    bool FueReproducido(string? idDeJwt);
    void Recordar(string? idDeJwt);
}
