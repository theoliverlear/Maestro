using Maestro.Biblioteca.Traducción.Modelos;

namespace Maestro.Biblioteca.Traducción.Comunicación.Solicitud;

public record SolicitudTraducción(string Texto, LenguajeTraducible LenguajeDeOrigen);
