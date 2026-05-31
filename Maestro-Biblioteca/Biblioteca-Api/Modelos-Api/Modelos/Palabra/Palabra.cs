using System.Text.Json.Serialization;

namespace Maestro.Modelos.Palabra;

public class Palabra
{
    [JsonPropertyName("español")]
    private string español;
    [JsonPropertyName("inglés")]
    private string inglés;

    public Palabra()
    {
        this.español = string.Empty;
        this.inglés = string.Empty;
    }

    public Palabra(string español, string inglés)
    {
        this.español = español;
        this.inglés = inglés;
    }

    public string Español
    {
        get => this.español;
        set => this.español = value;
    }

    public string Inglés
    {
        get => this.inglés;
        set => this.inglés = value;
    }
}