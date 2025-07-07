using Maestro.Excepción;
using Maestro.Modelos.Conjugación.Diccionario.Columnas;
using Maestro.Modelos.Verbos;

namespace Maestro.Modelos.Conjugación.Diccionario;

public class ConstructorDiccionariosDeConjugación
{
    private string? _verbo;
    private Ánimo? _ánimo;
    private Tenso? _tenso;
    private Pronombre? _pronombre;

    public ConstructorDiccionariosDeConjugación()
    {

    }

    public ConstructorDiccionariosDeConjugación ConVerbo(string verbo)
    {
        this._verbo = verbo;
        return this;
    }

    public ConstructorDiccionariosDeConjugación ConÁnimo(Ánimo ánimo)
    {
        this._ánimo = ánimo;
        return this;
    }

    public ConstructorDiccionariosDeConjugación ConÁnimo(string ánimo)
    {
        this._ánimo = Ánimo.DeCuerda(ánimo);
        return this;
    }

    public ConstructorDiccionariosDeConjugación ConTenso(Tenso tenso)
    {
        this._tenso = tenso;
        return this;
    }

    public ConstructorDiccionariosDeConjugación ConTenso(string tenso)
    {
        this._tenso = Tenso.DeCuerda(tenso);
        return this;
    }

    public ConstructorDiccionariosDeConjugación ConPronombre(Pronombre pronombre)
    {
        this._pronombre = pronombre;
        return this;
    }

    public ConstructorDiccionariosDeConjugación ConPronombre(string pronombre)
    {
        this._pronombre = Pronombre.DeCuerda(pronombre);
        return this;
    }

    public string Construir()
    {
        if (this._verbo == null ||
            this._ánimo == null ||
            this._tenso == null ||
            this._pronombre == null)
        {
            throw new ExcepciónDeConstructorNoVálido();
        }
        return DiccionarioDeConjugación.ObtenerPorColumnas(this._verbo,
                                                           this._ánimo,
                                                           this._tenso,
                                                           this._pronombre);
    }
}