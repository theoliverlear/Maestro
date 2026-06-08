using Maestro.Biblioteca.Api.Modelos.Excepción;
using Maestro.Biblioteca.Api.Modelos.Conjugación.Diccionario.Columnas;
using Maestro.Biblioteca.Api.Modelos.Verbos;

namespace Maestro.Biblioteca.Api.Modelos.Conjugación.Diccionario;

public class ConstructorDiccionariosDeConjugación
{
    private string? _verbo;
    private ColumnaÁnimo? _ánimo;
    private ColumnaTensa? _tenso;
    private Pronombre? _pronombre;

    public ConstructorDiccionariosDeConjugación()
    {

    }

    public ConstructorDiccionariosDeConjugación ConVerbo(string verbo)
    {
        this._verbo = verbo;
        return this;
    }

    public ConstructorDiccionariosDeConjugación ConÁnimo(ColumnaÁnimo columnaÁnimo)
    {
        this._ánimo = columnaÁnimo;
        return this;
    }

    public ConstructorDiccionariosDeConjugación ConÁnimo(string ánimo)
    {
        this._ánimo = ColumnaÁnimo.DeCuerda(ánimo);
        return this;
    }

    public ConstructorDiccionariosDeConjugación ConTenso(ColumnaTensa columnaTensa)
    {
        this._tenso = columnaTensa;
        return this;
    }

    public ConstructorDiccionariosDeConjugación ConTenso(string tenso)
    {
        this._tenso = ColumnaTensa.DeCuerda(tenso);
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