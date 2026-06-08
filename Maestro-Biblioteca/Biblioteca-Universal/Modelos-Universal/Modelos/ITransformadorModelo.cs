namespace Maestro.Biblioteca.Universal.Modelos;

public interface ITransformadorModelo<TOriginal, TTransformado>
{
    TTransformado Transformar(TOriginal original);
}