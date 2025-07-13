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
}

interface PropsBotónConTexto {
    recursoDeImagen?: never;
    texto: string;
    alHacerClic?: () => void;
}

type PropsBotón = PropsBotónConImagen | PropsBotónConTexto;

function Botón(props: PropsBotón): ReactElement {
    return (
        <div className={"botón"}>
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