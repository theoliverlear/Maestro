import './SelectorSegmentadoCrítico.scss';
import type {ReactElement} from "react";

import {OpciónPromocionalCríticos} from "../../../../modelos/crítico/tipos.ts";

interface PropsSelectorSegmentadoCrítico<T extends string> {
    opciones: OpciónPromocionalCríticos<T>[];
    valor: T;
    alCambiar: (valor: T) => void;
}

function SelectorSegmentadoCrítico<T extends string>(props: PropsSelectorSegmentadoCrítico<T>): ReactElement {
    return (
        <div className={"selector-segmentado-crítico"}>
            {props.opciones.map((opción: OpciónPromocionalCríticos<T>) => (
                <button
                    key={opción.valor}
                    type={"button"}
                    className={props.valor === opción.valor ? "activo" : ""}
                    onClick={() => props.alCambiar(opción.valor)}>
                    {opción.etiqueta}
                </button>
            ))}
        </div>
    );
}

export default SelectorSegmentadoCrítico;
