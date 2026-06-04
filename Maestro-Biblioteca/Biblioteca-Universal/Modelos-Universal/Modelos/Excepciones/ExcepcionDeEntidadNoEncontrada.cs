namespace Maestro.Biblioteca.Universal.Modelos.Excepciones;

public class ExcepcionDeEntidadNoEncontrada : Exception
{
    private const string MensajePredeterminado = "Entidad no encontrada";

    public ExcepcionDeEntidadNoEncontrada() : base(MensajePredeterminado)
    {
    }

    public ExcepcionDeEntidadNoEncontrada(string mensaje) : base(mensaje)
    {
    }

    public ExcepcionDeEntidadNoEncontrada(IIdentificable<object?> entidad)
        : base(FormatearMensaje(MensajePredeterminado, entidad))
    {
    }

    public ExcepcionDeEntidadNoEncontrada(string mensaje, IIdentificable<object?> entidad)
        : base(FormatearMensaje(mensaje, entidad))
    {
    }

    public static ExcepcionDeEntidadNoEncontrada Desde<TId>(IIdentificable<TId> entidad)
    {
        return new ExcepcionDeEntidadNoEncontrada(FormatearMensaje(MensajePredeterminado, entidad));
    }

    public static ExcepcionDeEntidadNoEncontrada Desde<TId>(string mensaje, IIdentificable<TId> entidad)
    {
        return new ExcepcionDeEntidadNoEncontrada(FormatearMensaje(mensaje, entidad));
    }

    private static string FormatearMensaje<TId>(string mensaje, IIdentificable<TId> entidad)
    {
        return $"{mensaje}: ID {entidad.Id} ({entidad.GetType().Name})";
    }
}
