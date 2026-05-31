import './ConsolaDeRegistro.scss';
import {ReactElement, useState} from "react";
import EntradasDeRegistro
    from "../grupos-elementos-entrada/entradas-de-registro/EntradasDeRegistro.tsx";
import MensajeDeAutorización
    from "../mensaje-de-autorización/MensajeDeAutorización.tsx";
import {
    EstadosDeValidezDeAutorización
} from "../modelos/EstadosDeValidezDeAutorización.ts";
import {
    GenSolicitudDeRegistro
} from "../../../../modelos/autorización/GenSolicitudDeRegistro.ts";
import {
    ServicioDeRegistroHttp
} from "../../../../servicios/http/autorización/ServicioDeRegistroHttp.ts";
import {usarInyectar} from "../../../../servicios/id/ProveedorDeServicios.ts";

function ConsolaDeRegistro(): ReactElement {
    const [mensajeDeAutorización, asignarMensajeDeAutorización] = useState<EstadosDeValidezDeAutorización>(EstadosDeValidezDeAutorización.VÁLIDO);
    const [solicitudDeRegistro, asignarSolicitudDeRegistro] = useState<GenSolicitudDeRegistro>(new GenSolicitudDeRegistro());

    const servicioDeRegistroHttp: ServicioDeRegistroHttp = usarInyectar(ServicioDeRegistroHttp);
    function gestionarCambioDeSolicitud(solicitud: GenSolicitudDeRegistro): void {
        asignarSolicitudDeRegistro(solicitud);
    }

    function manejarCambioDeMensaje(mensaje: EstadosDeValidezDeAutorización): void {
        asignarMensajeDeAutorización(mensaje);
    }

    async function manejarEnvío(éxito: boolean): Promise<void> {
        if (éxito) {
            await servicioDeRegistroHttp.registrar(solicitudDeRegistro.obtenerModelo());
        }
    }

    return (
        <div className={"consola-de-registro"}>
            <EntradasDeRegistro cambioPetición={gestionarCambioDeSolicitud}
                                sobreCambioDeMensaje={manejarCambioDeMensaje}
                                alEnviar={manejarEnvío}/>
            <MensajeDeAutorización mensaje={mensajeDeAutorización}/>
        </div>
    );
}

export default ConsolaDeRegistro;