import './AnclaDeCasa.scss';
import {ReactElement} from "react";
import Imagen from "../../grupos-elementos-nativos/imagen/Imagen.tsx";
import {
    recursoDeImagenDelLogotipo, recursoDeImagenDelLogotipoTransparente
} from "../../../../activos/recursosDeImagen.ts";
import {Link} from "react-router-dom";

function AnclaDeCasa(): ReactElement {
    return (
        <Link to={"/"} className={"enlace-sin-estilo"}>
            <div className={"ancla-de-casa"}>
                <Imagen recursoDeImagen={recursoDeImagenDelLogotipoTransparente}/>
            </div>
        </Link>
    );
}

export default AnclaDeCasa;