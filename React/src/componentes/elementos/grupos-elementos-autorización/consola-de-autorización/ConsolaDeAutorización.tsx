import './ConsolaDeAutorización.scss';
import {ReactElement} from "react";
import ConsolaDeInicioDeSesión
    from "../consola-de-inicio-de-sesión/ConsolaDeInicioDeSesión.tsx";
import ConsolaDeRegistro from "../consola-de-registro/ConsolaDeRegistro.tsx";

function ConsolaDeAutorización(): ReactElement {
    return (
        <div className={"consola-de-autorización"}>
            <ConsolaDeRegistro/>
            <ConsolaDeInicioDeSesión/>
        </div>
    );
}

export default ConsolaDeAutorización;