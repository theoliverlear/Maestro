namespace Maestro.Biblioteca.Api.Comunicación.Solicitud.Autorización;

public record SolicitudDeRegistro(string CorreoElectrónico,
                                  string Contraseña) : SolicitudInicioDeSesión(CorreoElectrónico, Contraseña);
