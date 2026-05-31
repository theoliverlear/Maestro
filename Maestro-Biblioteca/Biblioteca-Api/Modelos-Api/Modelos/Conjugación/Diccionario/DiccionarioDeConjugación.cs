using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Maestro.Excepción;
using Maestro.Modelos.Conjugación.Diccionario.Columnas;

namespace Maestro.Modelos.Conjugación.Diccionario;

using DiccionarioBase = Dictionary<string, Dictionary<string,
                        Dictionary<string, FilaDeConjugación>>>;

public class DiccionarioDeConjugación
{
    public static DiccionarioBase Diccionario = InicializarDiccionario();

    private static DiccionarioBase InicializarDiccionario()
    {
        using CsvReader csv = InicializarCsv();
        IEnumerable<FilaDeConjugación> filas = csv.GetRecords<FilaDeConjugación>();
        DiccionarioBase diccionario = filas
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

    public static bool ContieneVerbo(string verbo)
    {
        return Diccionario.ContainsKey(verbo);
    }

    public static bool ContieneVerboConÁnimo(string verbo, string ánimo)
    {
        if (!ContieneVerbo(verbo))
        {
            return false;
        }
        return Diccionario[verbo].ContainsKey(ánimo);
    }

    public static bool ContieneVerboConÁnimoTenso(string verbo,
                                                  string ánimo,
                                                  string tenso)
    {
        if (!ContieneVerboConÁnimo(verbo, ánimo))
        {
            return false;
        }
        return Diccionario[verbo][ánimo].ContainsKey(tenso);
    }

    private static CsvReader InicializarCsv()
    {
        CsvReader? csv = null;
        try
        {
            string camino = Path.Combine(AppContext.BaseDirectory, @"Modelos/Conjugación/Diccionario/conjugaciones.csv");
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
        if (!ContieneVerbo(verbo))
        {
            throw new ExcepciónDeVerboNoAdmitidos(verbo);
        }
    }

    public static void DetectarÁnimoNoAdmitidos(string verbo, string ánimo)
    {
        if (!ContieneVerboConÁnimo(verbo, ánimo))
        {
            throw new ExcepciónDeÁnimoNoAdmitido(ánimo);
        }
    }

    public static void DetectarTensoNoAdmitidos(string verbo,
                                                string ánimo,
                                                string tenso)
    {
        if (!ContieneVerboConÁnimoTenso(verbo, ánimo, tenso))
        {
            throw new ExcepciónDeTensoNoAdmitidos(tenso);
        }
    }

    public static void DetectarExcepcionesDeDiccionario(string verbo,
                                                        string ánimo,
                                                        string tenso)
    {
        DetectarVerboNoAdmitidos(verbo);
        DetectarÁnimoNoAdmitidos(verbo, ánimo);
        DetectarTensoNoAdmitidos(verbo, ánimo, tenso);
    }

    public static string ObtenerPorColumnas(string verbo,
                                            Ánimo ánimo,
                                            Tenso tenso,
                                            Pronombre pronombre)
    {
        DetectarExcepcionesDeDiccionario(verbo, ánimo.CadenaDeÁnimo, tenso.CadenaDeTenso);
        FilaDeConjugación fila = Diccionario[verbo][ánimo.CadenaDeÁnimo][tenso.CadenaDeTenso];
        return ObtenerPorPronombre(fila, pronombre);
    }

    private static string ObtenerPorPronombre(FilaDeConjugación fila, Pronombre pronombre)
    {
        if (pronombre.EsYo())
        {
            return fila.Yo;
        }

        if (pronombre.EsTú())
        {
            return fila.Tú;
        }

        if (pronombre.EsÉl() || pronombre.EsElla() || pronombre.EsUsted())
        {
            return fila.Él;
        }

        if (pronombre.EsNosotros())
        {
            return fila.Nosotros;
        }

        if (pronombre.EsEllos() || pronombre.EsUstedes())
        {
            return fila.Ellos;
        }

        throw new ArgumentException("Pronombre no reconocido.", nameof(pronombre));
    }

    public static ConstructorDiccionariosDeConjugación Constructor()
    {
        return new ConstructorDiccionariosDeConjugación();
    }
}