namespace Maestro.Biblioteca.Universal.Modelos.Atributos;

[AttributeUsage(AttributeTargets.Method)]
public sealed class MedirTiempoAttribute : Attribute
{
    public bool EsRegistrado { get; }
    public long MilisegundosEsperados { get; }
    public bool DebePersistir { get; }

    public MedirTiempoAttribute(bool esRegistrado = true,
                                long milisegundosEsperados = -1,
                                bool debePersistir = false)
    {
        this.EsRegistrado = esRegistrado;
        this.MilisegundosEsperados = milisegundosEsperados;
        this.DebePersistir = debePersistir;
    }
}
