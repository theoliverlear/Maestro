namespace Maestro.Biblioteca.Universal.Modelos;

public abstract class ModeloTransformado<TOriginal, TTransformado> : ITransformadorModelo<TOriginal, TTransformado>
{
    public abstract TTransformado Transformar(TOriginal original);
}