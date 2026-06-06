import './PanelDeSesiónCrítico.scss'
import type {ReactElement} from "react"
import {FocoCrítico, ModoCrítico} from "../../../../modelos/crítico/tipos.ts"

interface PropsPanelDeSesiónCrítico {
    modo: ModoCrítico;
    foco: FocoCrítico;
    longitud: number;
}

function PanelDeSesiónCrítico(props: PropsPanelDeSesiónCrítico): ReactElement {
    return (
        <aside className={"panel-de-sesión-crítico"}>
            <div className={"barra-de-panel-crítico"}>
                <span>Sesión</span>
                <strong>Preparada</strong>
            </div>
            <article>
                <span>Modo</span>
                <strong>{props.modo}</strong>
            </article>
            <article>
                <span>Foco</span>
                <strong>{props.foco}</strong>
            </article>
            <article>
                <span>Extensión</span>
                <strong>{props.longitud} caracteres</strong>
            </article>
            <div className={"nota-de-sesión-crítico"}>
                <strong>Consejo</strong>
                <p>Una buena crítica necesita intención: explica qué querías decir, no solo qué escribiste.</p>
            </div>
        </aside>
    )
}

export default PanelDeSesiónCrítico
