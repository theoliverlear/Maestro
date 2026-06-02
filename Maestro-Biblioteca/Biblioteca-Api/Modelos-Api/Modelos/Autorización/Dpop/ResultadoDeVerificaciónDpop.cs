namespace Maestro.Modelos.Autorización.Dpop;

// TODO: Mal olor de código, es excesivamente anulable.
public sealed record ResultadoDeVerificaciónDpop(ContextoDePruebaDpop? Contexto,
                                                 string? Razón)
{
    public bool EsVálido => this.Contexto != null;
}
