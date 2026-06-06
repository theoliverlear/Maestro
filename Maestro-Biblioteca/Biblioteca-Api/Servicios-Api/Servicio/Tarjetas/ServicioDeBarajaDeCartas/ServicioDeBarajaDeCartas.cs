using Maestro.Biblioteca.Api.Comunicación.Respuesta.Operaciones;
using Maestro.Biblioteca.Api.Entidad.Tarjeta;
using Maestro.Biblioteca.Api.Entidad.Usuario;
using Maestro.Biblioteca.Api.Modelos.Operaciones;
using Maestro.Biblioteca.Universal.Repositorio;
using Maestro.Biblioteca.Api.Repositorio.Tarjetas.BarajaDeCartas;
using Maestro.Biblioteca.Api.Servicio.BaseDatos.ServicioDeBaseDatos;
using Maestro.Biblioteca.Api.Servicio.Usuarios.ServicioDeUsuario;

namespace Maestro.Biblioteca.Api.Servicio.Tarjetas.ServicioDeBarajaDeCartas;

public class ServicioDeBarajaDeCartas : ServicioDeBaseDatos<BarajaDeCartas>, IServicioDeBarajaDeCartas
{
    private readonly IServicioDeUsuario _servicioDeUsuario;
    private readonly IBarajaDeCartasDeRepositorio _barajaDeCartasDeRepositorio;

    public ServicioDeBarajaDeCartas(IServicioDeUsuario servicioDeUsuario,
                                    IBarajaDeCartasDeRepositorio barajaDeCartasDeRepositorio,
                                    IRepositorio repositorio) : base(repositorio)
    {
        this._servicioDeUsuario = servicioDeUsuario;
        this._barajaDeCartasDeRepositorio = barajaDeCartasDeRepositorio;
    }

    public async Task<RespuestaDeÉxitoDeOperación> GuardarEnUsuarioAsíncrono(BarajaDeCartas cartas,
                                                                             Usuario usuario)
    {
        cartas.Usuario = usuario;
        usuario.BarajasDeCartas.Add(cartas);
        await this._servicioDeUsuario.AgregarAsíncrono(usuario);
        await this._barajaDeCartasDeRepositorio.AgregarAsíncrono(cartas);
        EstadoDeOperación estado = EstadoDeOperación.ÉxitoDeOperación;
        return new(estado.OperaciónExitosa, estado.Mensaje);
    }

    public async Task<RespuestaDeÉxitoDeOperación> GuardarTodasTarjetasAsíncrono(BarajaDeCartas cartas)
    {
        return await this.GuardarTodasTarjetasAsíncrono(cartas.Cartas);
    }

    public async Task<RespuestaDeÉxitoDeOperación> GuardarTodasTarjetasAsíncrono(ICollection<Tarjeta> cartas)
    {
        foreach (Tarjeta carta in cartas)
        {
            await this._barajaDeCartasDeRepositorio.ActualizarAsíncrono(carta);
        }
        EstadoDeOperación estado = EstadoDeOperación.ÉxitoDeOperación;
        return new(estado.OperaciónExitosa, estado.Mensaje);
    }

    public Task EliminarAsíncrono(BarajaDeCartas entidad)
    {
        throw new NotImplementedException();
    }

    public Task EliminarAsíncrono(int id)
    {
        throw new NotImplementedException();
    }

    public Task ActualizarAsíncrono(BarajaDeCartas entidad)
    {
        throw new NotImplementedException();
    }

    public ValueTask<BarajaDeCartas> AgregarAsíncrono(BarajaDeCartas entidad)
    {
        throw new NotImplementedException();
    }
}
