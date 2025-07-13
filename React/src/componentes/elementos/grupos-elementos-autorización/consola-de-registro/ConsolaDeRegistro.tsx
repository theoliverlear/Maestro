import './ConsolaDeRegistro.scss';
import {ReactElement} from "react";
import EntradasDeRegistro
    from "../grupos-elementos-entrada/entradas-de-registro/EntradasDeRegistro.tsx";

function ConsolaDeRegistro(): ReactElement {
    return (
        <div className={"consola-de-registro"}>
            <EntradasDeRegistro/>
        </div>
    );
}

export default ConsolaDeRegistro;