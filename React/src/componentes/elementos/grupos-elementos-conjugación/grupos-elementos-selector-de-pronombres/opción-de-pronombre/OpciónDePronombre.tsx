import './OpciónDePronombre.scss';
import {ReactElement} from "react";
import {Pronombre} from "./modelos/tipos.ts";
import Título from "../../../grupos-elementos-texto/título/Título.tsx";
import {TipoDeEtiqueta} from "../../../../../modelos/html/TipoDeEtiqueta.ts";

interface PropsOpciónDePronombre {
    pronombre: Pronombre;
    enSeleccionar: (pronombre: Pronombre) => void;
    estáSeleccionado?: boolean;
}

function OpciónDePronombre(props: PropsOpciónDePronombre): ReactElement {
    function selecciónDeMango(): void {
        props.enSeleccionar(props.pronombre);
    }

    function obtenerClases(): string {
        let claseBase: string = "opción-de-pronombre";
        if (props.estáSeleccionado) {
            claseBase += " seleccionado";
        }
        return claseBase;
    }

    return (
        <div className={obtenerClases()}
             onClick={selecciónDeMango}>
            <Título texto={props.pronombre} tipoDeEtiqueta={TipoDeEtiqueta.H4}/>
        </div>
    );
}

export default OpciónDePronombre;