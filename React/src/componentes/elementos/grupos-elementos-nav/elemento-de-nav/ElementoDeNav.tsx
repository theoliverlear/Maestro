import type {ReactElement} from "react";
import Título from "../../grupos-elementos-texto/título/Título.tsx";
import {TipoDeEtiqueta} from "../../../../modelos/html/TipoDeEtiqueta.ts";
import "./ElementoDeNav.scss";
import {Link} from "react-router-dom";

interface PropsElementoDeNav {
    texto: string;
    enlace: string;
}

function ElementoDeNav(props: PropsElementoDeNav): ReactElement {
    return (
        <Link to={props.enlace} className={"enlace-sin-estilo"}>
            <div className={"elemento-de-nav"}>
                <Título texto={props.texto} tipoDeEtiqueta={TipoDeEtiqueta.H4}/>
            </div>
        </Link>
    );
}
export default ElementoDeNav;