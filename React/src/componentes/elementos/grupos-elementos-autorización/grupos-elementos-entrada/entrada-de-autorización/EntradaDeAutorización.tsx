import './EntradaDeAutorización.scss';
import {ReactElement} from "react";
import {
    TipoDeEntradaDeAutorización
} from "./modelos/TipoDeEntradaDeAutorización.ts";
import Título from "../../../grupos-elementos-texto/título/Título.tsx";
import {TipoDeEtiqueta} from "../../../../../modelos/html/TipoDeEtiqueta.ts";
import Entrada from "../../../grupos-elementos-nativos/entrada/Entrada.tsx";
import {
    TipoDeEntrada
} from "../../../grupos-elementos-nativos/entrada/modelos/TipoDeEntrada.ts";

interface PropsEntradaDeAutorización {
    tipo: TipoDeEntradaDeAutorización;
}

function EntradaDeAutorización(props: PropsEntradaDeAutorización): ReactElement {
    function obtenerTipoDeEntrada(): TipoDeEntrada {
        switch (props.tipo) {
            case TipoDeEntradaDeAutorización.CONTRASEÑA:
            case TipoDeEntradaDeAutorización.CONFIRMAR_CONTRASEÑA:
                return TipoDeEntrada.CONTRASEÑA;
            case TipoDeEntradaDeAutorización.NOMBRE_DE_USUARIO:
            case TipoDeEntradaDeAutorización.CORREO_ELECTRÓNICO:
                return TipoDeEntrada.TEXTO;
            default:
                throw new Error(`Tipo de entrada desconocido: ${props.tipo}`);
        }
    }

    return (
        <div className={"entrada-de-autorización"}>
            <Título texto={props.tipo} tipoDeEtiqueta={TipoDeEtiqueta.H5}/>
            <Entrada tipo={obtenerTipoDeEntrada()} enLaEntrada={() => null}/>
        </div>
    );
}

export default EntradaDeAutorización;