namespace Maestro.Biblioteca.Crítico.Comunicacion.Respuesta;

public class RespuestaCrítico
{
    public bool Exito { get; set; }
    public string CargaJson { get; set; } = "{}";
    public string? Mensaje { get; set; }

    public static RespuestaCrítico Correcta(string cargaJson = "{}", string? mensaje = null)
    {
        return new RespuestaCrítico
        {
            Exito = true,
            CargaJson = cargaJson,
            Mensaje = mensaje
        };
    }

    public static RespuestaCrítico Error(string? mensaje)
    {
        return new RespuestaCrítico
        {
            Exito = false,
            CargaJson = "{}",
            Mensaje = mensaje
        };
    }
}
