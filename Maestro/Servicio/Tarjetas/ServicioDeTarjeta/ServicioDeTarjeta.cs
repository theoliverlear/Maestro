using Maestro.Entidad.Tarjeta;
using Maestro.Repositorio;
using Maestro.Repositorio.Tarjetas;
using Maestro.Servicio.BaseDatos.ServicioDeBaseDatos;

namespace Maestro.Servicio.Tarjetas.ServicioDeTarjeta;

public class ServicioDeTarjeta : ServicioDeBaseDatos<Tarjeta>, IServicioDeTarjeta
{
    private readonly ITarjetasDeRepositorio _tarjetasDeRepositorio;

    public ServicioDeTarjeta(ITarjetasDeRepositorio tarjetasDeRepositorio,
                             IRepositorio repositorio) : base(repositorio)
    {
        this._tarjetasDeRepositorio = tarjetasDeRepositorio;
    }
}