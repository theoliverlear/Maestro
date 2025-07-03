using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Maestro.Excepción;

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
                TrimOptions = TrimOptions.Trim
            });
            return csv;
        }
        catch
        {
            csv?.Dispose();
            throw;
        }
    }

    public static void DetectarVerboNoAdmitidos(string verbo)
    {
        if (!Diccionario.ContainsKey(verbo))
        {
            throw new ExcepciónDeVerboNoAdmitido(verbo);
        }
    }

    public static string ObtenerPorPronombre(string verbo, Pronombre pronombre)
    {
        if (pronombre.EsYo())
        {
            return ObtenerYo(verbo);
        }

        if (pronombre.EsTú())
        {
            return ObtenerTú(verbo);
        }

        if (pronombre.EsÉl() || pronombre.EsElla() || pronombre.EsUsted())
        {
            return ObtenerÉl(verbo);
        }

        if (pronombre.EsNosotros())
        {
            return ObtenerNosotros(verbo);
        }

        if (pronombre.EsEllos() || pronombre.EsUstedes())
        {
            return ObtenerEllos(verbo);
        }

        throw new ArgumentException("Pronombre no reconocido.", nameof(pronombre));
    }

    public static string ObtenerYo(string verbo)
    {
        DetectarVerboNoAdmitidos(verbo);
        return Diccionario[verbo]["Indicativo"]["Presente"].Yo;
    }

    public static string ObtenerTú(string verbo)
    {
        DetectarVerboNoAdmitidos(verbo);
        return Diccionario[verbo]["Indicativo"]["Presente"].Tú;
    }

    public static string ObtenerÉl(string verbo)
    {
        DetectarVerboNoAdmitidos(verbo);
        return Diccionario[verbo]["Indicativo"]["Presente"].Él;
    }

    public static string ObtenerNosotros(string verbo)
    {
        DetectarVerboNoAdmitidos(verbo);
        return Diccionario[verbo]["Indicativo"]["Presente"].Nosotros;
    }

    public static string ObtenerEllos(string verbo)
    {
        DetectarVerboNoAdmitidos(verbo);
        return Diccionario[verbo]["Indicativo"]["Presente"].Ellos;
    }
}