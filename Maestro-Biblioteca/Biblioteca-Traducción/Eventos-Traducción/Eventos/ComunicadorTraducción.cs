using Maestro.Biblioteca.Traducción.Comunicación.Respuesta;
using Maestro.Biblioteca.Traducción.Comunicación.Solicitud;
using Maestro.Biblioteca.Universal.Eventos;

namespace Maestro.Biblioteca.Traducción.Eventos;

public class ComunicadorTraducción :
    ControladorDeComunicadorDeSolicitud<SolicitudTraducción, RespuestaTraducción>
{
    private readonly IPublicadorDeEventos _publicador;

    public ComunicadorTraducción(IPublicadorDeEventos publicador)
    {
        this._publicador = publicador;
    }

    protected override IPublicadorDeEventos PublicadorDeEventos
    {
        get { return this._publicador; }
    }
}
