using System.Text.Json.Serialization;

namespace Maestro.Modelos.Palabra;

public class ListaPalabrasConDificultad
{
    [JsonPropertyName("palabras")]
    private List<PalabraConDificultad> palabras;
    public ListaPalabrasConDificultad()
    {
        this.palabras = new List<PalabraConDificultad>();
    }

    public PalabraConDificultad this[int index]
    {
        get => this.palabras[index];
        set => this.palabras[index] = value;
    }

    public List<PalabraConDificultad> Palabras
    {
        get => this.palabras;
        set => this.palabras = value;
    }
}