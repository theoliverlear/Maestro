import './MensajeDeAutorización.scss';
import {ReactElement} from "react";
import {
    EstadosDeValidezDeAutorización
} from "../modelos/EstadosDeValidezDeAutorización.ts";
import Título from "../../grupos-elementos-texto/título/Título.tsx";
import {TipoDeEtiqueta} from "../../../../modelos/html/TipoDeEtiqueta.ts";

interface PropsMensajeDeAutorización {
    mensaje: EstadosDeValidezDeAutorización;
}

function MensajeDeAutorización(props: PropsMensajeDeAutorización): ReactElement {
    function esMensajeVálido(): boolean {
        return props.mensaje === EstadosDeValidezDeAutorización.VÁLIDO;
    }
    return (
        <>
            {!esMensajeVálido() &&
                <div className={"mensaje-de-autorización"}>
                        <Título texto={props.mensaje}
                                tipoDeEtiqueta={TipoDeEtiqueta.H4}/>
                </div>}
        </>
    );
}

export default MensajeDeAutorización;