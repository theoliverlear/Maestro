import './SelectorDePronombres.scss';
import {ReactElement} from "react";
import {pronombres} from "../opción-de-pronombre/modelos/tipos.ts";
import OpciónDePronombre from "../opción-de-pronombre/OpciónDePronombre.tsx";

function SelectorDePronombres(): ReactElement {
    return (
        <div className={"selector-de-pronombres"}>
            {pronombres.map((pronombre: string, índice: number) => <OpciónDePronombre pronombre={pronombre} key={índice}/>)}
        </div>
    );
}

export default SelectorDePronombres;