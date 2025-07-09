import type {ReactElement} from "react";
import "./BarraDeNav.scss";
import ElementoDeNav from "../elemento-de-nav/ElementoDeNav.tsx";
import AnclaDeCasa from "../ancla-de-casa/AnclaDeCasa.tsx";
import {
    EnlaceDeElemento,
    enlacesDeBarraDeNav,
    enlacesDelDesplegablesDeHerramientas,
    enlacesDelDesplegablesDeJuegos
} from "../../../../activos/activosDeEnlaceDeElementos.ts";
import MenúDesplegableDeNav
    from "../menú-desplegable-de-nav/MenúDesplegableDeNav.tsx";
import AnclaDeCuenta from "../ancla-de-cuenta/AnclaDeCuenta.tsx";

function BarraDeNav(): ReactElement {
    return (
        <div className={"barra-de-nav"}>
            <AnclaDeCasa/>
            <nav>
                <MenúDesplegableDeNav enlaceDelElementoDesplegable={enlacesDelDesplegablesDeHerramientas}/>
                <MenúDesplegableDeNav enlaceDelElementoDesplegable={enlacesDelDesplegablesDeJuegos}/>
                {enlacesDeBarraDeNav.map((enlaceDeElemento: EnlaceDeElemento) => {
                    return <ElementoDeNav enlaceDeElemento={enlaceDeElemento}
                                          key={enlaceDeElemento.texto}/>;
                })}
            </nav>
            <AnclaDeCuenta/>
        </div>
    );
}

export default BarraDeNav;