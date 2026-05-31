import './BotónParaCrearBaraja.scss';
import {ReactElement} from "react";
import Botón from "../../grupos-elementos-nativos/botón/Botón.tsx";

interface PropsBotónParaCrearBaraja {
    alHacerClic: (visible: boolean) => void;
}

function BotónParaCrearBaraja(props: PropsBotónParaCrearBaraja): ReactElement {
    return  (
        <div className={"botón-para-crear-baraja"}>
            <Botón texto={"Crear Baraja"} alHacerClic={() => props.alHacerClic(true)}/>
        </div>
    );
}

export default BotónParaCrearBaraja;