import type {ReactElement} from "react";
import "./BarraDeNav.scss";
import ElementoDeNav from "../elemento-de-nav/ElementoDeNav.tsx";
import AnclaDeCasa from "../ancla-de-casa/AnclaDeCasa.tsx";

function BarraDeNav(): ReactElement {
    return (
        <div className={"barra-de-nav"}>
            <AnclaDeCasa/>
            <nav>
                <ElementoDeNav texto={"Panel"} enlace={"/panel"}/>
                <ElementoDeNav texto={"Conjugador"} enlace={"/conj"}/>
                <ElementoDeNav texto={"Perfil"} enlace={"/perfil"}/>
            </nav>
        </div>
    );
}

export default BarraDeNav;