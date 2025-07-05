import "./Conjugador.scss";
import type {ReactElement} from "react";
import SelectorDePronombres
    from "../../elementos/grupos-elementos-conjugación/grupos-elementos-selector-de-pronombres/selector-de-pronombres/SelectorDePronombres.tsx";

function Conjugador(): ReactElement {
    return (
        <div className={"conjugador"}>
            <SelectorDePronombres/>
        </div>
    );
}
export default Conjugador;