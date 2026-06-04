namespace Maestro.Biblioteca.Universal.Modelos.Atributos;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public sealed class RegistrableAttribute : Attribute
{
    public string Nombre { get; }
    public bool Redactar { get; }

    public RegistrableAttribute(string nombre = "", bool redactar = false)
    {
        this.Nombre = nombre;
        this.Redactar = redactar;
    }
}
