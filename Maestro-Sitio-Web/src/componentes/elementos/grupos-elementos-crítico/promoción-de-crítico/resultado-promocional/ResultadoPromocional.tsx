import './ResultadoPromocional.scss';
import type {ReactElement} from "react";

import {PuntoPromocionalDeCrítica} from "../../../../../modelos/crítico/tipos.ts";
import {
    resultadosDeEjemplo
} from "../../../../../activos/PuntoPromocionalDeCrítica.activos.ts";

function ResultadoPromocional(): ReactElement {
    return (
        <div className={"resultado-de-crítico"}>
            <div className={"barra-de-panel-crítico"}>
                <span>Respuesta</span>
                <strong>Crítica guiada</strong>
            </div>
            {resultadosDeEjemplo.map((resultado: PuntoPromocionalDeCrítica) => (
                <article key={resultado.título}>
                    <strong>{resultado.título}</strong>
                    <p>{resultado.texto}</p>
                </article>
            ))}
        </div>
    );
}

export default ResultadoPromocional;
