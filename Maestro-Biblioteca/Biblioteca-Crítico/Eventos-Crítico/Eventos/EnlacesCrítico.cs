using Maestro.Biblioteca.Universal.Eventos;

namespace Maestro.Biblioteca.Crítico.Eventos;

public static class EnlacesCrítico
{
    public static readonly IEnlaceDeEvento Solicitudes = new EnlaceDeEvento("criticoRequests-out-0");
    public static readonly IEnlaceDeEvento SolicitudesEntrantes = new EnlaceDeEvento("criticoRequests-in-0");
    public static readonly IEnlaceDeEvento Respuestas = new EnlaceDeEvento("criticoResponses-out-0");
    public static readonly IEnlaceDeEvento RespuestasEntrantes = new EnlaceDeEvento("criticoResponses-in-0");
}
