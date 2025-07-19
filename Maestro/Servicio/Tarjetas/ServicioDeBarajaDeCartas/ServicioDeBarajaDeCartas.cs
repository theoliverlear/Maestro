using Maestro.Comunicación.Respuesta.Operaciones;
using Maestro.Entidad.Tarjeta;
using Maestro.Entidad.Usuario;
using Maestro.Modelos.Operaciones;
using Maestro.Repositorio;
using Maestro.Repositorio.Tarjetas.BarajaDeCartas;
using Maestro.Servicio.BaseDatos.ServicioDeBaseDatos;
using Maestro.Servicio.Usuarios.ServicioDeUsuario;

namespace Maestro.Servicio.Tarjetas.ServicioDeBarajaDeCartas;

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
        return new(EstadoDeOperación.ÉxitoDeOperación);
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
        return new(EstadoDeOperación.ÉxitoDeOperación);
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