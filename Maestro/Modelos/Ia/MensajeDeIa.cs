using System.ClientModel;
using OpenAI.Chat;

namespace Maestro.Modelos.Ia;
using Lombok.NET;

public class MensajeDeIa
{
    public MensajeDeIa()
    {
        string? claveApi = Environment.GetEnvironmentVariable("CLAVE_API_DE_OPEN_AI");
        if (string.IsNullOrEmpty(claveApi))
        {
            const string mensajeDeException = "No se puede crear un cliente" +
                                              " de chat sin una clave API.";
            throw new NullReferenceException(mensajeDeException);
        }
        this.Cliente = new ChatClient(
            model: "gpt-4o-mini",
            credential: new ApiKeyCredential(claveApi));
    }

    public async Task<string> ObtenerListaDePalabras()
    {
        const string mensaje = """
                         Genera una lista de palabras comunes en español.
                         Agrupa las palabras en una escala de dificultad del 1 al 10.
                         Escribe la respuesta en formato JSON como:
                         {
                             "1": {
                                 "español": "gato",
                                 "ingles": "cat"
                             },
                             ...
                             "10": {
                                 "español": "efímero",
                                 "ingles": "ephemeral"
                             }
                         }
                         Incluye solo el formato JSON en tu respuesta.
                         No incluyas comillas invertidas ni Markdown adicional.
                         """;
        string respuesta = await this.Charlar(mensaje);
        return respuesta;
    }

    private async Task<string> Charlar(string mensaje)
    {
        ChatCompletion respuesta = await this.Cliente.CompleteChatAsync(mensaje);
        return respuesta.Content[0].Text;
    }

    public ChatClient Cliente { get; set; }
}