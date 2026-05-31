using Maestro.Excepción;
using Newtonsoft.Json;

namespace Maestro.Modelos.Json;

public class JsonConstruido
{
    public static TClaseObjetivo ConvertirEnObjeto<TClaseObjetivo>(string json)
    {
        TClaseObjetivo? objeto = JsonConvert.DeserializeObject<TClaseObjetivo>(json);
        if (objeto is null)
        {
            throw new ExcepciónDeSerializaciónFallida(json);
        }
        return objeto;
    }
}