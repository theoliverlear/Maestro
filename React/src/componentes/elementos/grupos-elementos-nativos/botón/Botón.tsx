import './Botón.scss';
import {ReactElement} from "react";
import {RecursoDeImagen} from "../../../../activos/recursosDeImagen.ts";
import Imagen from "../imagen/Imagen.tsx";
import Título from "../../grupos-elementos-texto/título/Título.tsx";
import {TipoDeEtiqueta} from "../../../../modelos/html/TipoDeEtiqueta.ts";

interface PropsBotónConImagen {
    recursoDeImagen: RecursoDeImagen;
    texto?: never;
    alHacerClic?: () => void;
    nombreClase?: string;
}

interface PropsBotónConTexto {
    recursoDeImagen?: never;
    texto: string;
    alHacerClic?: () => void;
    nombreClase?: string;
}

type PropsBotón = PropsBotónConImagen | PropsBotónConTexto;

function Botón(props: PropsBotón): ReactElement {
    
    function obtenerClaseBase(): string {
        let clases: string = "botón";
        if (props.nombreClase) {
            clases += " " + props.nombreClase;
        }
        if (props.recursoDeImagen) {
            clases += " cuadrado";
        }
        return clases;
    }
    
    return (
        <div className={obtenerClaseBase()} onClick={props.alHacerClic}>
            {props.recursoDeImagen && (
                <Imagen recursoDeImagen={props.recursoDeImagen}/>
            )}
            {props.texto && (
                <Título texto={props.texto} tipoDeEtiqueta={TipoDeEtiqueta.H5}/>
            )}
        </div>
    );
}

export default Botón;