using Maestro.Datos;

namespace Maestro.Repositorio.Tarjetas.BarajaDeCartas;

public class BarajaDeCartasDeRepositorio : Repositorio, IBarajaDeCartasDeRepositorio
{
    public BarajaDeCartasDeRepositorio(ContextoDeBdMaestro bd) : base(bd)
    {

    }
}