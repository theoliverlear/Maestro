using Maestro.Modelos.Palabra;

namespace Maestro.Comunicación.Respuesta.Palabra.PalabraReal;

public class RespuestaDeListaPalabraReal
{
    public ListaPalabrasConDificultad ListaPalabras { get; }
    public RespuestaDeListaPalabraReal(ListaPalabrasConDificultad listaPalabras)
    {
        this.ListaPalabras = listaPalabras;
    }
}