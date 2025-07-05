import './AnclaDeCasa.scss';
import {ReactElement} from "react";
import Imagen from "../../grupos-elementos-nativos/imagen/Imagen.tsx";
import {
    recursoDeImagenDelLogotipo
} from "../../../../activos/recursosDeImagen.ts";
import {Link} from "react-router-dom";

function AnclaDeCasa(): ReactElement {
    return (
        <Link to={"/"} className={"enlace-sin-estilo"}>
            <div className={"ancla-de-casa"}>
                <Imagen recursoDeImagen={recursoDeImagenDelLogotipo}/>
            </div>
        </Link>
    );
}

export default AnclaDeCasa;