using Maestro.Modelos.Json;
using Maestro.Modelos.Palabra;

namespace Maestro.Modelos.Ia;

public class ClienteDePalabraReal : MensajeDeIa
{
    public ClienteDePalabraReal()
    {

    }


    public ListaPalabrasConDificultad ObtenerPalabras()
    {
        string json = this.ObtenerPalabraJson().GetAwaiter().GetResult();
        return JsonConstruido.ConvertirEnObjeto<ListaPalabrasConDificultad>(json);
    }

    public async Task<string> ObtenerPalabraJson()
    {
        const string mensaje = """
                               Genera una lista de palabras comunes en español.
                               Agrupa las palabras en una escala de dificultad del 1 al 10.
                               Escribe la respuesta en formato JSON como:
                               "palabras": [
                                   {
                                       "español": "gato",
                                       "inglés": "cat",
                                       "dificultad": 1
                                   },
                                   ...
                                   {
                                       "español": "efímero",
                                       "ingles": "ephemeral",
                                       "dificultad": 10
                                   }
                               ]
                               Incluye solo el formato JSON en tu respuesta.
                               No incluyas comillas invertidas ni Markdown adicional.
                               Genera tantos como puedas y asegúrate de incluir todos los números de dificultad del 1 al 10.
                               """;
        string respuesta = await this.Charlar(mensaje);
        return respuesta;
    }
}