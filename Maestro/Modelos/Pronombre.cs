namespace Maestro.Modelos;

public class Pronombre
{
    private string sujeto;
    public static readonly Pronombre Yo = new Pronombre("yo");
    public static readonly Pronombre Tú = new Pronombre("tú");
    public static readonly Pronombre Él = new Pronombre("él");
    public static readonly Pronombre Ella = new Pronombre("ella");
    public static readonly Pronombre Usted = new Pronombre("usted");
    public static readonly Pronombre Nosotros = new Pronombre("nosotros");
    public static readonly Pronombre Ellos = new Pronombre("ellos");
    public static readonly Pronombre Ustedes = new Pronombre("ustedes");

    public Pronombre(string sujeto)
    {
        this.sujeto = sujeto;
    }

    public bool EsYo() => this.Equals(Yo);
    public bool EsTú() => this.Equals(Tú);
    public bool EsÉl() => this.Equals(Él);
    public bool EsElla() => this.Equals(Ella);
    public bool EsUsted() => this.Equals(Usted);
    public bool EsNosotros() => this.Equals(Nosotros);
    public bool EsEllos() => this.Equals(Ellos);
    public bool EsUstedes() => this.Equals(Ustedes);




    public string Sujeto
    {
        get => this.sujeto;
        set => this.sujeto = value ?? string.Empty;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Pronombre pronombre)
        {
            return false;
        }
        return this.sujeto == pronombre.sujeto;
    }

    public override int GetHashCode()
    {
        return this.sujeto.GetHashCode();
    }
}