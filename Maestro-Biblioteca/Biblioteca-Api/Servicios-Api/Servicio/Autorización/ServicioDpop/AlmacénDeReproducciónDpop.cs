using Microsoft.Extensions.Caching.Memory;

namespace Maestro.Servicio.Autorización.ServicioDpop;

public class AlmacénDeReproducciónDpop : IAlmacénDeReproducciónDpop
{
    private readonly IMemoryCache _memoria;

    public AlmacénDeReproducciónDpop(IMemoryCache memoria)
    {
        this._memoria = memoria;
    }

    public bool FueReproducido(string? idDeJwt)
    {
        return !string.IsNullOrWhiteSpace(idDeJwt) &&
               this._memoria.TryGetValue(this.Clave(idDeJwt), out _);
    }

    public void Recordar(string? idDeJwt)
    {
        if (string.IsNullOrWhiteSpace(idDeJwt))
        {
            return;
        }

        this._memoria.Set(this.Clave(idDeJwt),
            true,
            TimeSpan.FromMinutes(2));
    }

    private string Clave(string idDeJwt)
    {
        return $"dpop:jti:{idDeJwt}";
    }
}
