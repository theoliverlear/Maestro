import './Autorización.scss';
import {ReactElement} from "react";
import ConsolaDeAutorización
    from "../../elementos/grupos-elementos-autorización/consola-de-autorización/ConsolaDeAutorización.tsx";

function Autorización(): ReactElement {
    return (
        <div className={"autorización"}>
            <ConsolaDeAutorización/>
        </div>
    );
}

export default Autorización;