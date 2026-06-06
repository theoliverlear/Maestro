import './RutaDeCrítica.scss';
import type {ReactElement} from "react";

import {PasoPromocionalDeCrítica} from "../../../../../modelos/crítico/tipos.ts";
import {
    pasosDeCrítica
} from "../../../../../activos/PasoPromocionalDeCrítica.activos.ts";

function RutaDeCrítica(): ReactElement {
    return (
        <section className={"ruta-de-crítica"}>
            <div className={"encabezado-de-sección"}>
                <p className={"ceja-promocional"}>Flujo de práctica</p>
                <h2>Un ciclo corto para escribir mejor.</h2>
            </div>
            <div className={"pasos-de-crítica"}>
                {pasosDeCrítica.map((paso: PasoPromocionalDeCrítica) => (
                    <article key={paso.título}>
                        <span>{paso.número}</span>
                        <h3>{paso.título}</h3>
                        <p>{paso.texto}</p>
                    </article>
                ))}
            </div>
        </section>
    );
}

export default RutaDeCrítica;
