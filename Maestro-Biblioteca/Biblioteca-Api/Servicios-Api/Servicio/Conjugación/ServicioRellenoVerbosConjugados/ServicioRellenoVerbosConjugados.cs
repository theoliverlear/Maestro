using Maestro.Biblioteca.Api.Entidad.Conjugación;
using Maestro.Biblioteca.Api.Modelos.Conjugación.Diccionario;
using Maestro.Biblioteca.Api.Servicio.Conjugación.ServicioTransformadorConjugadorRellenador;
using Maestro.Biblioteca.Universal.Repositorio;
using Microsoft.Extensions.Configuration;

namespace Maestro.Biblioteca.Api.Servicio.Conjugación.ServicioRellenoVerbosConjugados;

// El propósito de esta clase es cargar retroactivamente datos de archivos CSV
// en modelos y almacenarlos en la base de datos PostgreSQL.
public class ServicioRellenoVerbosConjugados : IServicioRellenoVerbosConjugados
{
    private const string RutaConfiguración =
        "Rellenos:VerbosConjugados:Ejecutar";

    private readonly IConfiguration configuración;
    private readonly IRepositorio repositorio;
    private readonly IServicioTransformadorConjugadorRellenador transformador;

    public ServicioRellenoVerbosConjugados(
        IConfiguration configuración,
        IRepositorio repositorio,
        IServicioTransformadorConjugadorRellenador transformador)
    {
        this.configuración = configuración;
        this.repositorio = repositorio;
        this.transformador = transformador;
    }

    public async Task RellenarSiConfiguradoAsync(CancellationToken cancellationToken = default)
    {
        bool debeRellenar = this.configuración.GetValue<bool>(RutaConfiguración);
        if (!debeRellenar)
        {
            return;
        }

        IEnumerable<FilaDeConjugación> filas = DiccionarioDeConjugación
            .Diccionario
            .Values
            .SelectMany(porÁnimo => porÁnimo.Values)
            .SelectMany(porTenso => porTenso.Values);

        foreach (FilaDeConjugación fila in filas)
        {
            cancellationToken.ThrowIfCancellationRequested();

            VerboConjugado verboConjugado = this.transformador.Transformar(fila);
            await this.repositorio.AgregarAsíncrono(verboConjugado);
        }
    }
}
