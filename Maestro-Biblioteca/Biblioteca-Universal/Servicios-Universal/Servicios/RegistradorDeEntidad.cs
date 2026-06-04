using System.Collections;
using System.Collections.Concurrent;
using System.Reflection;
using Maestro.Biblioteca.Universal.Modelos.Atributos;

namespace Maestro.Biblioteca.Universal.Servicios;

public static class RegistradorDeEntidad
{
    private static readonly ConcurrentDictionary<Type, IReadOnlyList<MemberInfo>> MiembrosRegistrablesPorTipo = new();

    public static IReadOnlyDictionary<string, string> ObtenerContenidoRegistrable(object entidad)
    {
        Type tipo = entidad.GetType();
        IReadOnlyList<MemberInfo> miembros = MiembrosRegistrablesPorTipo.GetOrAdd(tipo, ObtenerMiembrosRegistrables);
        Dictionary<string, string> contenido = new();

        foreach (MemberInfo miembro in miembros)
        {
            RegistrableAttribute? atributo = miembro.GetCustomAttribute<RegistrableAttribute>();
            if (atributo == null)
            {
                continue;
            }

            string nombre = string.IsNullOrWhiteSpace(atributo.Nombre) ? miembro.Name : atributo.Nombre;
            object? valor = atributo.Redactar ? "***" : LeerValor(miembro, entidad);
            contenido[nombre] = FormatearValor(valor);
        }

        return contenido;
    }

    private static IReadOnlyList<MemberInfo> ObtenerMiembrosRegistrables(Type tipo)
    {
        const BindingFlags banderas = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        List<MemberInfo> miembros = new();
        Type? tipoActual = tipo;

        while (tipoActual != null && tipoActual != typeof(object))
        {
            miembros.AddRange(tipoActual
                .GetProperties(banderas)
                .Where(propiedad => propiedad.GetIndexParameters().Length == 0 &&
                                    propiedad.GetCustomAttribute<RegistrableAttribute>() != null));
            miembros.AddRange(tipoActual
                .GetFields(banderas)
                .Where(campo => !campo.IsStatic &&
                                campo.GetCustomAttribute<RegistrableAttribute>() != null));
            tipoActual = tipoActual.BaseType;
        }

        return miembros;
    }

    private static object? LeerValor(MemberInfo miembro, object entidad)
    {
        return miembro switch
        {
            PropertyInfo propiedad => propiedad.GetValue(entidad),
            FieldInfo campo => campo.GetValue(entidad),
            _ => null
        };
    }

    private static string FormatearValor(object? valor)
    {
        if (valor == null)
        {
            return "null";
        }

        if (valor is string texto)
        {
            return texto;
        }

        if (valor is IDictionary diccionario)
        {
            return "{" + string.Join(", ", diccionario.Keys
                .Cast<object?>()
                .Where(clave => clave != null)
                .Select(clave => $"{FormatearValor(clave)}: {FormatearValor(diccionario[clave!])}")) + "}";
        }

        if (valor is IEnumerable enumerable)
        {
            return "[" + string.Join(", ", enumerable.Cast<object?>().Select(FormatearValor)) + "]";
        }

        return valor.ToString() ?? string.Empty;
    }
}
