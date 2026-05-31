using System.ClientModel;
using OpenAI;
using OpenAI.Chat;

namespace Maestro.Modelos.Ia;
using Lombok.NET;

public class ClienteDeIa
{
    private ChatClient _cliente;
    private float _temperatura;

    public ClienteDeIa() : this(0.7f)
    {

    }

    private ClienteDeIa(float temperatura)
    {
        this._temperatura = temperatura;
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

    public async Task<string> Charlar(string mensaje)
    {
        var mensajes = new[]
        {
            new UserChatMessage(mensaje)
        };
        var opciones = new ChatCompletionOptions
        {
            Temperature = this._temperatura
        };
        ChatCompletion respuesta = await this.Cliente.CompleteChatAsync(mensajes, opciones);
        return respuesta.Content[0].Text;
    }

    public ChatClient Cliente
    {
        get => _cliente;
        set => _cliente = value;
    }
}