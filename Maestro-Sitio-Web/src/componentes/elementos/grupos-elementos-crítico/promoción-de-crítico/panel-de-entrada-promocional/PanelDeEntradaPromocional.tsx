import './PanelDeEntradaPromocional.scss';
import type {ReactElement} from "react";

function PanelDeEntradaPromocional(): ReactElement {
    return (
        <div className={"panel-de-entrada-crítico"}>
            <div className={"barra-de-panel-crítico"}>
                <span>Borrador</span>
                <strong>Español escrito</strong>
            </div>
            <label htmlFor={"entrada-promocional-crítico"}>Tu intento</label>
            <textarea
                id={"entrada-promocional-crítico"}
                value={"Me gusta mucho esta ciudad porque tiene una historia muy fuerte."}
                readOnly
            />
            <div className={"controles-de-crítico"}>
                <button type={"button"} className={"activo"}>Natural</button>
                <button type={"button"}>Formal</button>
                <button type={"button"}>Cultural</button>
            </div>
        </div>
    );
}

export default PanelDeEntradaPromocional;

