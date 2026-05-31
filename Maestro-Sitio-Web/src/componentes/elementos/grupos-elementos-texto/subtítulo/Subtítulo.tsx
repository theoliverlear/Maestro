import './Subtítulo.scss';
import {TipoDeEtiqueta} from "../../../../modelos/html/TipoDeEtiqueta.ts";
import React, {ReactElement} from "react";

interface PropsSubtítulo {
    texto: string,
    tipoDeEtiqueta: TipoDeEtiqueta,
    alHacerClic?: (texto: string) => void,
    nombreClase?: string
}

function Subtítulo(props: PropsSubtítulo): ReactElement {
    function textoDeTamaño(): ReactElement {
        switch (props.tipoDeEtiqueta) {
            case TipoDeEtiqueta.H1:
                return <h1>{props.texto}</h1>;
            case TipoDeEtiqueta.H2:
                return <h2>{props.texto}</h2>;
            case TipoDeEtiqueta.H3:
                return <h3>{props.texto}</h3>;
            case TipoDeEtiqueta.H4:
                return <h4>{props.texto}</h4>;
            case TipoDeEtiqueta.H5:
                return <h5>{props.texto}</h5>;
            case TipoDeEtiqueta.H6:
                return <h6>{props.texto}</h6>;
            case TipoDeEtiqueta.P:
                return <p>{props.texto}</p>;
            case TipoDeEtiqueta.SPAN:
                return <span>{props.texto}</span>;
            default:
                return <h1>{props.texto}</h1>;
        }
    }

    return (
        <div className={`subtítulo ${props.nombreClase ? props.nombreClase : ''}`}
             onClick={() => props.alHacerClic ? props.alHacerClic(props.texto) : null}>
            {textoDeTamaño()}
        </div>
    );

}

export default Subtítulo;