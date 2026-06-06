using Maestro.Biblioteca.Universal.Repositorio;
using Maestro.Biblioteca.Universal.Componentes.Datos;

namespace Maestro.Biblioteca.Api.Repositorio.Tarjetas;

public class TarjetasDeRepositorio : Repositorio<ContextoDeBdMaestro>, ITarjetasDeRepositorio
{
    public TarjetasDeRepositorio(ContextoDeBdMaestro bd) : base(bd)
    {

    }
}
