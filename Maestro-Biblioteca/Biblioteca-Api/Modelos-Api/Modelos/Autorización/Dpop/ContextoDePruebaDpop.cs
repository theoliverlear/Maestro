namespace Maestro.Modelos.Autorización.Dpop;

public sealed record ContextoDePruebaDpop(string HuellaDeClave,
                                          string? IdDeJwt,
                                          string MétodoHttp,
                                          string UrlHttp);
