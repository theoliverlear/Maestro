namespace Maestro.Modelos.Normalizador;

public class Normalizador
{
    public static string NormalizarCaracteresEspañoles(string texto)
    {
        if (string.IsNullOrEmpty(texto))
        {
            return texto;
        }
        string[][] reemplazos =
        [
            ["á", "a"], ["Á", "A"], ["é", "e"], ["É", "E"], ["í", "i"], 
            ["Í", "I"], ["ó", "o"], ["Ó", "O"], ["ú", "u"], ["Ú", "U"],
            ["ñ", "n"], ["Ñ", "N"], ["ü", "u"], ["Ü", "U"]
        ];
        foreach (string[] reemplazo in reemplazos)
        {
            texto = texto.Replace(reemplazo[0], reemplazo[1]);
        }
        return texto;
    }
}