using Maestro.Biblioteca.Api.Comunicación.Respuesta.Operaciones;
using Maestro.Biblioteca.Api.Entidad.Tarjeta;
using Maestro.Biblioteca.Api.Entidad.Usuario;
using Maestro.Biblioteca.Api.Servicio.BaseDatos.ServicioDeBaseDatos;

namespace Maestro.Biblioteca.Api.Servicio.Tarjetas.ServicioDeBarajaDeCartas;

public interface IServicioDeBarajaDeCartas : IServicioDeBaseDatos<BarajaDeCartas>
{
    Task<RespuestaDeÉxitoDeOperación> GuardarEnUsuarioAsíncrono(BarajaDeCartas cartas, Usuario usuario);
    Task<RespuestaDeÉxitoDeOperación> GuardarTodasTarjetasAsíncrono(BarajaDeCartas cartas);
    Task<RespuestaDeÉxitoDeOperación> GuardarTodasTarjetasAsíncrono(ICollection<Tarjeta> cartas);
}