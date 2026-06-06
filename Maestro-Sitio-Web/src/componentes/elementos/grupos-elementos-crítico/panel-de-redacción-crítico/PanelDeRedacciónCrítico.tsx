import './PanelDeRedacciónCrítico.scss';
import type {ReactElement} from "react";
import SelectorSegmentadoCrítico from "../selector-segmentado-crítico/SelectorSegmentadoCrítico.tsx";
import {FocoCrítico, ModoCrítico} from "../../../../modelos/crítico/tipos.ts";
import {
    focosPromocionalDeCríticos,
    modosPromocionalDeCríticos
} from "../../../../activos/OpciónPromocionalCríticos.activos.ts";

interface PropsPanelDeRedacciónCrítico {
    texto: string;
    modo: ModoCrítico;
    foco: FocoCrítico;
    alCambiarTexto: (valor: string) => void;
    alCambiarModo: (valor: ModoCrítico) => void;
    alCambiarFoco: (valor: FocoCrítico) => void;
    alCriticar: () => void;
}

function PanelDeRedacciónCrítico(props: PropsPanelDeRedacciónCrítico): ReactElement {
    return (
        <section className={"panel-de-redacción-crítico"}>
            <div className={"barra-de-panel-crítico"}>
                <span>Entrada</span>
                <strong>Borrador activo</strong>
            </div>
            <label htmlFor={"texto-para-crítico"}>Texto para criticar</label>
            <textarea
                id={"texto-para-crítico"}
                value={props.texto}
                onChange={evento => props.alCambiarTexto(evento.target.value)}
            />
            <div className={"grupo-de-controles-crítico"}>
                <div>
                    <span>Modo</span>
                    <SelectorSegmentadoCrítico opciones={modosPromocionalDeCríticos} valor={props.modo} alCambiar={props.alCambiarModo}/>
                </div>
                <div>
                    <span>Foco</span>
                    <SelectorSegmentadoCrítico opciones={focosPromocionalDeCríticos} valor={props.foco} alCambiar={props.alCambiarFoco}/>
                </div>
            </div>
            <button type={"button"} className={"botón-principal-crítico"} onClick={props.alCriticar}>
                Criticar texto
            </button>
        </section>
    );
}

export default PanelDeRedacciónCrítico;
