using Maestro.Biblioteca.Universal.Repositorio;
using Maestro.Biblioteca.Universal.Componentes.Datos;

namespace Maestro.Biblioteca.Api.Repositorio.Tarjetas.BarajaDeCartas;

public class BarajaDeCartasDeRepositorio : Repositorio<ContextoDeBdMaestro>, IBarajaDeCartasDeRepositorio
{
    public BarajaDeCartasDeRepositorio(ContextoDeBdMaestro bd) : base(bd)
    {

    }
}
