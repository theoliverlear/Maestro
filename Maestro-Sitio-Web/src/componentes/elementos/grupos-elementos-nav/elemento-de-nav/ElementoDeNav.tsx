import type {ReactElement} from "react";
import Título from "../../grupos-elementos-texto/título/Título.tsx";
import {TipoDeEtiqueta} from "../../../../modelos/html/TipoDeEtiqueta.ts";
import "./ElementoDeNav.scss";
import {Link} from "react-router-dom";
import {
    EnlaceDeElemento
} from "../../../../activos/activosDeEnlaceDeElementos.ts";
import {
    recursoDeImagenDeIconoDesplegable
} from "../../../../activos/recursosDeImagen.ts";
import Imagen from "../../grupos-elementos-nativos/imagen/Imagen.tsx";

interface PropsElementoDeNav {
    enlaceDeElemento: EnlaceDeElemento;
    esDesplegable?: boolean;
}

function ElementoDeNav(props: PropsElementoDeNav): ReactElement {
    function añadirFlecha(): boolean {
        if (!props.esDesplegable) {
            return false;
        } else {
            return props.esDesplegable;
        }
    }

    function obtenerClasesDeTítulo(): string {
        if (añadirFlecha()) {
            return "icono-ajustado";
        } else {
            return "";
        }
    }

    return (
        <Link to={props.enlaceDeElemento.enlace}
              className={"enlace-sin-estilo"}
              draggable={false}>
            <div className={"elemento-de-nav"}>
                <Título texto={props.enlaceDeElemento.texto}
                        tipoDeEtiqueta={TipoDeEtiqueta.H5}
                        nombreClase={obtenerClasesDeTítulo()}/>
                {añadirFlecha() && <Imagen recursoDeImagen={recursoDeImagenDeIconoDesplegable}/>}
            </div>
        </Link>
    );
}
export default ElementoDeNav;