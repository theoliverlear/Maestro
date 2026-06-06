import './ModosDeCrítica.scss';
import type {ReactElement} from "react";

import {ModoPromocionalDeCrítica} from "../../../../../modelos/crítico/tipos.ts";
import {
    modosDeCrítica
} from "../../../../../activos/ModoPromocionalDeCrítica.activos.ts";

function ModosDeCrítica(): ReactElement {
    return (
        <section className={"sección-de-modos-crítico"}>
            <div className={"encabezado-de-sección"}>
                <p className={"ceja-promocional"}>Perfiles</p>
                <h2>La crítica cambia según el contexto.</h2>
            </div>
            <div className={"cuadrícula-de-modos-crítico"}>
                {modosDeCrítica.map((modo: ModoPromocionalDeCrítica) => (
                    <article className={"modo-de-crítica"} key={modo.título}>
                        <span>{modo.etiqueta}</span>
                        <h3>{modo.título}</h3>
                        <p>{modo.texto}</p>
                    </article>
                ))}
            </div>
        </section>
    );
}

export default ModosDeCrítica;
