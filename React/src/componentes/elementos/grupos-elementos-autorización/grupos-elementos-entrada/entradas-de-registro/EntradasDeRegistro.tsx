import './EntradasDeRegistro.scss';
import {ReactElement} from "react";
import EntradaDeAutorización
    from "../entrada-de-autorización/EntradaDeAutorización.tsx";
import {
    TipoDeEntradaDeAutorización
} from "../entrada-de-autorización/modelos/TipoDeEntradaDeAutorización.ts";
import Título from "../../../grupos-elementos-texto/título/Título.tsx";
import {TipoDeEtiqueta} from "../../../../../modelos/html/TipoDeEtiqueta.ts";
import Botón from "../../../grupos-elementos-nativos/botón/Botón.tsx";

function EntradasDeRegistro(): ReactElement {
    return (
        <div className={"entradas-de-registro"}>
            <Título texto={"Registro"} tipoDeEtiqueta={TipoDeEtiqueta.H3}/>
            <EntradaDeAutorización tipo={TipoDeEntradaDeAutorización.NOMBRE_DE_USUARIO}/>
            <EntradaDeAutorización tipo={TipoDeEntradaDeAutorización.CORREO_ELECTRÓNICO}/>
            <EntradaDeAutorización tipo={TipoDeEntradaDeAutorización.CONTRASEÑA}/>
            <EntradaDeAutorización tipo={TipoDeEntradaDeAutorización.CONFIRMAR_CONTRASEÑA}/>
            <Botón texto={"Registro"}/>
        </div>
    );
}

export default EntradasDeRegistro;
