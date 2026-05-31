import './SelectorDePronombres.scss';
import {ReactElement, useEffect, useState} from "react";
import OpciónDePronombre from "../opción-de-pronombre/OpciónDePronombre.tsx";
import {
    Pronombre,
    pronombres
} from "../../../../../modelos/conjugación/tipos.ts";

interface PropsSelectorDePronombres {
    enLaSelección: (pronombre: Pronombre) => void;
}

function SelectorDePronombres(props: PropsSelectorDePronombres): ReactElement {
    const [pronombreSeleccionado, asignarPronombreSeleccionado] = useState<Pronombre>("Yo");
    function selecciónDeMango(pronombre: Pronombre): void {
        asignarPronombreSeleccionado(pronombre);
        props.enLaSelección(pronombre);
    }

    function esComponenteSeleccionado(pronombreComponente: Pronombre): boolean {
        return pronombreSeleccionado === pronombreComponente;
    }

    useEffect(() => {
        pronombres.forEach((pronombre: Pronombre) => {
            if (esComponenteSeleccionado(pronombre)) {
                asignarPronombreSeleccionado(pronombre);
            }
        });
    }, [pronombreSeleccionado]);
    return (
        <div className={"selector-de-pronombres"}>
            {pronombres.map((pronombre: string, índice: number) =>
                <OpciónDePronombre pronombre={pronombre}
                                   enSeleccionar={selecciónDeMango}
                                   estáSeleccionado={esComponenteSeleccionado(pronombre)}
                                   key={índice}/>)}
        </div>
    );
}

export default SelectorDePronombres;