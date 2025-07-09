import "./Conjugador.scss";
import {ReactElement, useEffect, useMemo, useState} from "react";
import SelectorDePronombres
    from "../../elementos/grupos-elementos-conjugación/grupos-elementos-selector-de-pronombres/selector-de-pronombres/SelectorDePronombres.tsx";
import EntradaConTítulo
    from "../../elementos/grupos-elementos-entrada/entrada-con-título/EntradaConTítulo.tsx";
import {
    TipoDeEntrada
} from "../../elementos/grupos-elementos-nativos/entrada/modelos/TipoDeEntrada.ts";
import {usarConjugación} from "../../../manos/usarConjugación.ts";
import Título from "../../elementos/grupos-elementos-texto/título/Título.tsx";
import {TipoDeEtiqueta} from "../../../modelos/html/TipoDeEtiqueta.ts";
import {Pronombre} from "../../../modelos/conjugación/tipos.ts";
import debounce from "lodash/debounce";


function Conjugador(): ReactElement {
    const [pronombreSeleccionado, asignarPronombreSeleccionado] = useState<Pronombre>("Yo");
    const [verbo, asignarVerbo] = useState<string>("");
    const {
        verboConjugado,
        conjugado
    } = usarConjugación();

    function manejarEntrada(valor: string | number): void {
        asignarVerbo(valor as string);
        manejarLaConjugación();
    }

    const manejarConjugaciónSinRebote = useMemo(() => {
        return debounce((nuevoVerbo: string, nuevoPronombre: Pronombre) => {
            if (nuevoVerbo.trim().length < 2) {
                return;
            }
            conjugado(nuevoVerbo, nuevoPronombre);
        }, 150);
    }, [conjugado])

    function manejarLaConjugación(): void {
        manejarConjugaciónSinRebote(verbo, pronombreSeleccionado);
    }

    function manejarLaSelecciónDePronombre(pronombre: Pronombre): void {
        asignarPronombreSeleccionado(pronombre);
        manejarLaConjugación();
    }

    function conjugaciónDelVerboObtener(): string {
        if (verboConjugado.trim().length === 0) {
            return "¡Conjuga un verbo!";
        }
        return verboConjugado;
    }

    useEffect(() => {
        return () => manejarConjugaciónSinRebote.cancel();
    }, [manejarConjugaciónSinRebote]);

    useEffect(() => {
        if (verbo.trim().length >= 2) {
            manejarLaConjugación();
        }
    }, [verbo]);

    useEffect(() => {
        manejarLaConjugación();
    }, [pronombreSeleccionado]);

    function normalizarEntradaDelVerbo(valor: string | number): string | number {
        let valorComoCadena: string = String(valor);
        const regex: RegExp = /[^a-zA-ZáéíóúÁÉÍÓÚñÑüÜ]/g;
        valorComoCadena = valorComoCadena.replace(regex, "");
        if (valorComoCadena.length > 25) {
            valorComoCadena = valorComoCadena.slice(0, 25);
        }
        return valorComoCadena.trim();
    }

    return (
        <div className={"conjugador"}>
            <Título nombreClase={"título-del-verbo-conjugado"}
                    texto={conjugaciónDelVerboObtener()}
                    tipoDeEtiqueta={TipoDeEtiqueta.H3}/>
            <EntradaConTítulo textoDelTítulo={"Verbo"}
                              enLaEntrada={manejarEntrada}
                              max={25}
                              normalizarEntrada={normalizarEntradaDelVerbo}
                              tipoDeEntrada={TipoDeEntrada.TEXTO}
                              marcadorDePosición={"Ej. \"hablar\""}/>
            <SelectorDePronombres enLaSelección={manejarLaSelecciónDePronombre}/>
        </div>
    );
}
export default Conjugador;