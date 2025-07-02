using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace Maestro.Modelos.Conjugación;

using DiccionarioDeConjugación = Dictionary<string, Dictionary<string,
                                 Dictionary<string, FilaDeConjugación>>>;

public class Conjugador
{
    public static DiccionarioDeConjugación Diccionario = InicializarDiccionario();

    private static DiccionarioDeConjugación InicializarDiccionario()
    {
        using CsvReader csv = InicializarCsv();
        IEnumerable<FilaDeConjugación> filas = csv.GetRecords<FilaDeConjugación>();
        DiccionarioDeConjugación diccionario = filas
            .GroupBy(fila => fila.Infinitivo)
            .ToDictionary(groupo => groupo.Key,
                groupo => groupo.GroupBy(fila => fila.Ánimo)
                    .ToDictionary(
                        groupoDeEstadoÁnimo => groupoDeEstadoÁnimo.Key,
                        groupoDeEstadoÁnimo =>
                            groupoDeEstadoÁnimo.ToDictionary(tenso => tenso.Tenso,
                                tenso => tenso)));
        return diccionario;
    }

    private static CsvReader InicializarCsv()
    {
        CsvReader? csv = null;
        try
        {
            string camino = Path.Combine(AppContext.BaseDirectory, @"Modelos/Conjugación/conjugaciones.csv");
            StreamReader lectora = new StreamReader(camino);
            csv = new CsvReader(lectora, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                BadDataFound = null,
                MissingFieldFound = null,
                TrimOptions = CsvHelper.Configuration.TrimOptions.Trim
            });
            return csv;
        }
        catch
        {
            csv?.Dispose();
            throw;
        }
    }

    public static string ObtenerPorPronombre(string verbo, Pronombre pronombre)
    {
        return string.Empty;
    }

    public static string ObtenerYo(string verbo)
    {
        return Diccionario[verbo]["Indicativo"]["Presente"].Yo;
    }

    private string verbo;
}