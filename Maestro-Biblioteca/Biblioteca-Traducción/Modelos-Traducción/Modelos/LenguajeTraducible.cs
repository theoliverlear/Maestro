using System.Text.Json.Serialization;

namespace Maestro.Biblioteca.Traducción.Modelos;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum LenguajeTraducible
{
    Español,
    Inglés
}
