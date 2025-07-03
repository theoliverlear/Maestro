import './Casa.scss';
import type {ReactElement} from "react";
import Título from "../../elementos/grupos-elementos-texto/título/Título.tsx";
import {TipoDeEtiqueta} from "../../../modelos/html/TipoDeEtiqueta.ts";
import Subtítulo
    from "../../elementos/grupos-elementos-texto/subtítulo/Subtítulo.tsx";

function Casa(): ReactElement {
    return (
        <div className={"casa"}>
            <div className={"texto-de-apertura-casa"}>
                <Título texto={"¡Maestro!"}
                        tipoDeEtiqueta={TipoDeEtiqueta.H1}/>
                <Subtítulo texto={"Un punto de inflexión en la educación española."}
                           tipoDeEtiqueta={TipoDeEtiqueta.H5}/>
            </div>
        </div>
    );
}

export default Casa;