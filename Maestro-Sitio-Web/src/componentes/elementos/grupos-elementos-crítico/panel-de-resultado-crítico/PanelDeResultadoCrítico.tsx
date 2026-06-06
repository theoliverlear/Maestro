import './PanelDeResultadoCrítico.scss';
import type {ReactElement} from "react";

import {TarjetaDeResultado} from "../../../../modelos/crítico/tipos.ts";

interface PropsPanelDeResultadoCrítico {
    resultado: TarjetaDeResultado[];
}

function PanelDeResultadoCrítico(props: PropsPanelDeResultadoCrítico): ReactElement {
    return (
        <section className={"panel-de-resultado-crítico"}>
            <div className={"barra-de-panel-crítico"}>
                <span>Salida</span>
                <strong>Crítica estructurada</strong>
            </div>
            <div className={"tarjetas-de-resultado-crítico"}>
                {props.resultado.map((tarjeta: TarjetaDeResultado) => (
                    <article key={tarjeta.título}>
                        <strong>{tarjeta.título}</strong>
                        <p>{tarjeta.texto}</p>
                    </article>
                ))}
            </div>
        </section>
    );
}

export default PanelDeResultadoCrítico;
