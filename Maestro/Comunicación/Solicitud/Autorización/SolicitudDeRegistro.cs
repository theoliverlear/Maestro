namespace Maestro.Comunicación.Solicitud.Autorización;

public record SolicitudDeRegistro(string NombreDeUsuario,
                                  string Contraseña,
                                  string CorreoElectrónico) : SolicitudInicioDeSesión(NombreDeUsuario, Contraseña);