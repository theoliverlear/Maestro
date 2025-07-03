using Maestro.Modelos.Conjugación;

namespace Maestro.Modelos.Verbos;

public class Verbo
{
    private string verbo;
    private SufijoVerbal sufijoVerbal;

    public Verbo()
    {
        this.verbo = string.Empty;
        this.sufijoVerbal = SufijoVerbal.Ar;
    }

    public Verbo(string verbo)
    {
        this.verbo = verbo;
        this.sufijoVerbal = SufijoVerbal.ObtenerSufijo(verbo);
    }

    public string Conjugado(Pronombre pronombre)
    {
        if (pronombre.EsYo())
        {
            return Conjugador.ObtenerYo(this.verbo);
        }

        if (pronombre.EsTú())
        {
            return Conjugador.ObtenerTú(this.verbo);
        }

        if (pronombre.EsElla() || pronombre.EsÉl() || pronombre.EsUsted())
        {
            return Conjugador.ObtenerÉl(this.verbo);
        }

        if (pronombre.EsUstedes() || pronombre.EsEllos())
        {
            return Conjugador.ObtenerEllos(this.verbo);
        }

        if (pronombre.EsNosotros())
        {
            return Conjugador.ObtenerNosotros(this.verbo);
        }
        return string.Empty;
    }
}