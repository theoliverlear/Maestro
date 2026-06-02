using Maestro.Biblioteca.Crítico.Comunicacion.Respuesta;
using Maestro.Biblioteca.Crítico.Comunicacion.Solicitud;
using Maestro.Biblioteca.Universal.Eventos;

namespace Maestro.Biblioteca.Crítico.Eventos;

public class ComunicadorCrítico :
    ControladorDeComunicadorDeSolicitud<SolicitudCrítico, RespuestaCrítico>
{
    private readonly IPublicadorDeEventos _publicador;

    public ComunicadorCrítico(IPublicadorDeEventos publicador)
    {
        this._publicador = publicador;
    }

    protected override IPublicadorDeEventos PublicadorDeEventos
    {
        get { return this._publicador; }
    }
}
