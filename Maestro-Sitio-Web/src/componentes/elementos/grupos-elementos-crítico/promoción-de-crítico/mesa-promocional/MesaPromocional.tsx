import './MesaPromocional.scss';
import type {ReactElement} from "react";
import PanelDeEntradaPromocional from "../panel-de-entrada-promocional/PanelDeEntradaPromocional.tsx";
import ResultadoPromocional from "../resultado-promocional/ResultadoPromocional.tsx";

function MesaPromocional(): ReactElement {
    return (
        <section className={"mesa-de-trabajo-crítico"}>
            <div className={"encabezado-de-crítico"}>
                <p className={"ceja-promocional"}>Crítico</p>
                <h1>Convierte cada intento en una lección.</h1>
                <p>
                    Escribe en español y recibe una revisión separada por elogio, crítica, corrección y
                    mejora. La meta es ayudarte a sonar más claro, natural y situado.
                </p>
            </div>

            <div className={"consola-de-crítico"} aria-label={"Vista de trabajo de Crítico"}>
                <PanelDeEntradaPromocional/>
                <ResultadoPromocional/>
            </div>
        </section>
    );
}

export default MesaPromocional;

