using Maestro.Datos;

namespace Maestro.Repositorio.Tarjetas;

public class TarjetasDeRepositorio : Repositorio, ITarjetasDeRepositorio
{
    public TarjetasDeRepositorio(ContextoDeBdMaestro bd) : base(bd)
    {

    }
}