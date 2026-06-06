using Maestro.Biblioteca.Api.Entidad.Tarjeta;
using Maestro.Biblioteca.Universal.Repositorio;
using Maestro.Biblioteca.Api.Repositorio.Tarjetas;
using Maestro.Biblioteca.Api.Servicio.BaseDatos.ServicioDeBaseDatos;

namespace Maestro.Biblioteca.Api.Servicio.Tarjetas.ServicioDeTarjeta;

public class ServicioDeTarjeta : ServicioDeBaseDatos<Tarjeta>, IServicioDeTarjeta
{
    private readonly ITarjetasDeRepositorio _tarjetasDeRepositorio;

    public ServicioDeTarjeta(ITarjetasDeRepositorio tarjetasDeRepositorio,
                             IRepositorio repositorio) : base(repositorio)
    {
        this._tarjetasDeRepositorio = tarjetasDeRepositorio;
    }
}