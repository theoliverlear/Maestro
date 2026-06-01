namespace Maestro.Comunicación.Solicitud.Autorización;

public record SolicitudDeRegistro(string CorreoElectrónico,
                                  string Contraseña) : SolicitudInicioDeSesión(CorreoElectrónico, Contraseña);
