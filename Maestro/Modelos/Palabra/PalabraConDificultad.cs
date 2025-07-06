using System.Text.Json.Serialization;

namespace Maestro.Modelos.Palabra;

public class PalabraConDificultad : Palabra
{
    [JsonPropertyName("dificultad")]
    private int dificultad;

    public PalabraConDificultad()
    {
        this.dificultad = 0;
    }

    public PalabraConDificultad(string español,
                                string inglés,
                                int dificultad) : base(español, inglés)
    {
        this.dificultad = dificultad;
    }

    public int Dificultad
    {
        get => this.dificultad;
        set => this.dificultad = value;
    }
}