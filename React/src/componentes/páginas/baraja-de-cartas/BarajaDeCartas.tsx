import './BarajaDeCartas.scss';
import {ReactElement, useState} from "react";
import BotónParaCrearBaraja
    from "../../elementos/grupos-elementos-baraja-de-cartas/botón-para-crear-baraja/BotónParaCrearBaraja.tsx";
import MenúParaCrearBaraja
    from "../../elementos/grupos-elementos-baraja-de-cartas/menú-para-crear-baraja/MenúParaCrearBaraja.tsx";

function BarajaDeCartas(): ReactElement {
    const [barajaCrearMenúVisible, asignarBarajaCrearMenúVisible] = useState<boolean>(false);
    function manejarClicEnMenú(visible: boolean): void {
        asignarBarajaCrearMenúVisible(visible);
    }
    return (
        <div className={"baraja-de-cartas"}>
            {!barajaCrearMenúVisible && <BotónParaCrearBaraja alHacerClic={manejarClicEnMenú}/>}
            {barajaCrearMenúVisible && <MenúParaCrearBaraja/>}
        </div>
    );
}

export default BarajaDeCartas;