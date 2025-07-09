import './EntradaConTítulo.scss';
import {ReactElement} from "react";
import Título from "../../grupos-elementos-texto/título/Título.tsx";
import {TipoDeEtiqueta} from "../../../../modelos/html/TipoDeEtiqueta.ts";
import {
    TipoDeEntrada
} from "../../grupos-elementos-nativos/entrada/modelos/TipoDeEntrada.ts";
import Entrada from "../../grupos-elementos-nativos/entrada/Entrada.tsx";

interface PropsEntradaConTítulo {
    textoDelTítulo: string;
    tipoDeEntrada: TipoDeEntrada;
    enLaEntrada: (valor: string | number) => void;
    normalizarEntrada?: (valor: string | number) => string | number;
    marcadorDePosición?: string;
    min?: number;
    max?: number;
    valorPredeterminado?: number | string;
}

function EntradaConTítulo(props: PropsEntradaConTítulo): ReactElement {
    return (
        <div className={"entrada-con-título"}>
            <Título texto={props.textoDelTítulo} tipoDeEtiqueta={TipoDeEtiqueta.H4}/>
            <Entrada tipo={props.tipoDeEntrada}
                     enLaEntrada={props.enLaEntrada}
                     marcadorDePosición={props.marcadorDePosición}
                     min={props.min}
                     max={props.max}
                     normalizarEntrada={props.normalizarEntrada}
                     valorPredeterminado={props.valorPredeterminado}/>
        </div>
    );
}

export default EntradaConTítulo;