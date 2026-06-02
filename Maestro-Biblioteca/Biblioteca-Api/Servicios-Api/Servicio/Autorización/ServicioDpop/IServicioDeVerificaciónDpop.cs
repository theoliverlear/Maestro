using Maestro.Modelos.Autorización.Dpop;

namespace Maestro.Servicio.Autorización.ServicioDpop;

public interface IServicioDeVerificaciónDpop
{
    ContextoDePruebaDpop? Verificar(string? prueba,
                                    string método,
                                    string url,
                                    string? tokenDeAcceso = null);
    ResultadoDeVerificaciónDpop VerificarConResultado(string? prueba,
                                                      string método,
                                                      string url,
                                                      string? tokenDeAcceso = null);
}
