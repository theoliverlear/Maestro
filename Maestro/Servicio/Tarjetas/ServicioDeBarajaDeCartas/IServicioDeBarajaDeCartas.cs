using Maestro.Comunicación.Respuesta.Operaciones;
using Maestro.Entidad.Tarjeta;
using Maestro.Entidad.Usuario;
using Maestro.Servicio.BaseDatos.ServicioDeBaseDatos;

namespace Maestro.Servicio.Tarjetas.ServicioDeBarajaDeCartas;

public interface IServicioDeBarajaDeCartas : IServicioDeBaseDatos<BarajaDeCartas>
{
    Task<RespuestaDeÉxitoDeOperación> GuardarEnUsuarioAsíncrono(BarajaDeCartas cartas, Usuario usuario);
    Task<RespuestaDeÉxitoDeOperación> GuardarTodasTarjetasAsíncrono(BarajaDeCartas cartas);
    Task<RespuestaDeÉxitoDeOperación> GuardarTodasTarjetasAsíncrono(ICollection<Tarjeta> cartas);
}