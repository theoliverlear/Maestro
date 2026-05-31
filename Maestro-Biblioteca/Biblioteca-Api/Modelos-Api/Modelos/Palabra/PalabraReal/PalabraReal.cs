namespace Maestro.Modelos.Palabra.PalabraReal;

public class PalabraReal
{
    private ListaPalabrasConDificultad _palabras;
    private int _índiceDePalabraActual;
    private ModoAdivinanza _modoActual;
    public PalabraReal()
    {
        this._palabras = new ListaPalabrasConDificultad();
        this._índiceDePalabraActual = 0;
        this._modoActual = ModoAdivinanza.Español;
    }

    public PalabraReal(ListaPalabrasConDificultad palabras)
    {
        this._palabras = palabras;
        this._índiceDePalabraActual = 0;
        this._modoActual = ModoAdivinanza.Español;
    }

    public PalabraReal(ListaPalabrasConDificultad palabras, ModoAdivinanza modo)
    {
        this._palabras = palabras;
        this._índiceDePalabraActual = 0;
        this._modoActual = modo;
    }

    public void modoAleatorio()
    {
        this._modoActual = (ModoAdivinanza) new Random().Next(0, 2);
    }

    public bool esCorrectaSuposición(SuposiciónDePalabra suposición)
    {
        suposición.Modo = this._modoActual;
        suposición.Palabra = this._palabras[this._índiceDePalabraActual];
        return suposición.EsCorrecto();
    }
}