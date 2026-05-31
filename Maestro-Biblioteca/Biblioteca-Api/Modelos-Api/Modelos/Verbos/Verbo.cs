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
        return Conjugador.ConjugarConVerboPronombre(this.verbo,
                                                    pronombre.Sujeto);
    }
}