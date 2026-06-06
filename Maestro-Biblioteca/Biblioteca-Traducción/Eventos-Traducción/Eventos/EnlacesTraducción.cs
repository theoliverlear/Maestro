using Maestro.Biblioteca.Universal.Eventos;

namespace Maestro.Biblioteca.Traducción.Eventos;

public static class EnlacesTraducción
{
    public static readonly IEnlaceDeEvento Solicitudes = new EnlaceDeEvento("traduccionRequests-out-0");
    public static readonly IEnlaceDeEvento SolicitudesEntrantes = new EnlaceDeEvento("traduccionRequests-in-0");
    public static readonly IEnlaceDeEvento Respuestas = new EnlaceDeEvento("traduccionResponses-out-0");
    public static readonly IEnlaceDeEvento RespuestasEntrantes = new EnlaceDeEvento("traduccionResponses-in-0");
}
