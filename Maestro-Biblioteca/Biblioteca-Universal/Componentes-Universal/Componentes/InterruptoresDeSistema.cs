using Microsoft.Extensions.Options;

namespace Maestro.Biblioteca.Universal.Componentes;

public class InterruptoresDeSistema
{
    private readonly OpcionesDeCaracteristicasUniversales _opciones;

    public InterruptoresDeSistema(IOptions<OpcionesDeCaracteristicasUniversales> opciones)
    {
        this._opciones = opciones.Value;
    }

    public bool PuedeCargarDatosExternos
    {
        get { return this._opciones.CargarDatosExternos; }
    }

    public bool PuedeCosecharDatosExternos
    {
        get { return this._opciones.CosecharDatosExternos; }
    }
}
