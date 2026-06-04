namespace Maestro.Biblioteca.Universal.Eventos;

public interface IPublicadorDeEventos
{
    Task<bool> PublicarAsync<TCarga>(string nombreDeEnlace,
                                     TCarga carga,
                                     IReadOnlyDictionary<string, string>? encabezados = null,
                                     CancellationToken ct = default);
}
