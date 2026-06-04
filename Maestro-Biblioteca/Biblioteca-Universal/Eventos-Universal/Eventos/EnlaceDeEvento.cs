namespace Maestro.Biblioteca.Universal.Eventos;

public sealed class EnlaceDeEvento : IEnlaceDeEvento
{
    public string NombreDeEnlace { get; }

    public EnlaceDeEvento(string nombreDeEnlace)
    {
        this.NombreDeEnlace = nombreDeEnlace;
    }
}
