import './AnclaDeCuenta.scss';
import {Link} from "react-router-dom";
import Imagen from "../../grupos-elementos-nativos/imagen/Imagen.tsx";
import {
    recursoDeImagenDeIconoDeUsuarioPredeterminado
} from "../../../../activos/recursosDeImagen.ts";


function AnclaDeCuenta() {
    return (
        <Link to={"/cuenta"} className={"enlace-sin-estilo"}>
            <div className={"ancla-de-cuenta"}>
                <Imagen recursoDeImagen={recursoDeImagenDeIconoDeUsuarioPredeterminado}/>
            </div>
        </Link>
    );
}

export default AnclaDeCuenta;