import './OpciónDePronombre.scss';
import {ReactElement} from "react";
import {Pronombre} from "./modelos/tipos.ts";
import Título from "../../../grupos-elementos-texto/título/Título.tsx";
import {TipoDeEtiqueta} from "../../../../../modelos/html/TipoDeEtiqueta.ts";

interface PropsOpciónDePronombre {
    pronombre: Pronombre;
}

function OpciónDePronombre(props: PropsOpciónDePronombre): ReactElement {
    return (
        <div className={"opción-de-pronombre"}>
            <Título texto={props.pronombre} tipoDeEtiqueta={TipoDeEtiqueta.H4}/>
        </div>
    );
}

export default OpciónDePronombre;