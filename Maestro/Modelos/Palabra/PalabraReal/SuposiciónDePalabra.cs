namespace Maestro.Modelos.Palabra.PalabraReal;
using Maestro.Modelos.Normalizador;
public class SuposiciónDePalabra
{
    public static string MensajeDeInicModoIncorrecto = "El modo de " +
                                                        "adivinación no se" +
                                                        " inicializa correctamente.";
    private string _suposición;
    private Palabra _palabra;
    private ModoAdivinanza _modo;

    public SuposiciónDePalabra() : this(string.Empty, new Palabra(), ModoAdivinanza.Español)
    {

    }

    public SuposiciónDePalabra(string suposición, Palabra palabra) :
        this(suposición, palabra, ModoAdivinanza.Español)
    {

    }

    public SuposiciónDePalabra(string suposición,
                               Palabra palabra,
                               ModoAdivinanza modo)
    {
        this._suposición = suposición;
        this._modo = modo;
        this._palabra = palabra;
    }

    public bool EsCorrecto()
    {
        switch (this._modo)
        {
            case ModoAdivinanza.Español:
                return this.EsCorrectoEnEspañol();
            case ModoAdivinanza.Inglés:
                return this.EsCorrectoEnInglés();
            default:
                throw new ApplicationException(MensajeDeInicModoIncorrecto);
        }
    }


    private bool EsCorrectoEnInglés()
    {
        return ContieneRespuestaCorrecta(this._suposición, this._palabra.Inglés);
    }

    private bool EsCorrectoEnEspañol()
    {
        return ContieneRespuestaCorrecta(this._suposición, this._palabra.Español);
    }

    private static bool ContieneRespuestaCorrecta(string suposición,
                                                  string respuestaCorrecta)
    {
        suposición = Normalizador.NormalizarCaracteresEspañoles(suposición);
        respuestaCorrecta = Normalizador.NormalizarCaracteresEspañoles(respuestaCorrecta);
        return suposición.Contains(respuestaCorrecta, StringComparison.OrdinalIgnoreCase);
    }

    public ModoAdivinanza Modo
    {
        get => this._modo;
        set => this._modo = value;
    }

    public Palabra Palabra
    {
        get => this._palabra;
        set => this._palabra = value;
    }
}