import './ConsolaDeAutorización.scss';
import {ReactElement, useState} from "react";
import {Link} from "react-router-dom";
import ConsolaDeInicioDeSesión
    from "../consola-de-inicio-de-sesión/ConsolaDeInicioDeSesión.tsx";
import ConsolaDeRegistro from "../consola-de-registro/ConsolaDeRegistro.tsx";
import {
    TipoDeConsolaDeAutorización
} from "./modelos/TipoDeConsolaDeAutorización.ts";

function ConsolaDeAutorización(): ReactElement {
    const [tipoDeConsola, asignarTipoDeConsola] = useState<TipoDeConsolaDeAutorización>(TipoDeConsolaDeAutorización.REGISTRO);

    function esRegistro(): boolean {
        return tipoDeConsola === TipoDeConsolaDeAutorización.REGISTRO;
    }
    // TODO: Extraer texto a archivo de texto.
    return (
        <div className={"consola-de-autorización"}>
            {/* TODO: Reemplazar con icono. */}
            <Link to={"/"} className={"botón-de-cierre-de-autorización"} aria-label={"Cerrar autorización"}>
                ×
            </Link>

            <div className={"encabezado-de-autorización"}>
                <p>Cuenta de Maestro</p>
                <h2>{esRegistro() ? "Crea tu cuenta" : "Bienvenido de nuevo"}</h2>
                <span>
                    {esRegistro()
                        ? "Empieza a guardar tu progreso y preparar sesiones de estudio profundas."
                        : "Accede a tu panel y retoma tu práctica de español."}
                </span>
            </div>

            <div className={"pestañas-de-autorización"}>
                <button className={esRegistro() ? "activa" : ""}
                        type={"button"}
                        onClick={() => asignarTipoDeConsola(TipoDeConsolaDeAutorización.REGISTRO)}>
                    Registro
                </button>
                <button className={!esRegistro() ? "activa" : ""}
                        type={"button"}
                        onClick={() => asignarTipoDeConsola(TipoDeConsolaDeAutorización.ACCESO)}>
                    Acceso
                </button>
            </div>

            <div className={"cuerpo-de-autorización"}>
                {esRegistro() ? <ConsolaDeRegistro/> : <ConsolaDeInicioDeSesión/>}
            </div>

            <p className={"texto-de-cambio-de-autorización"}>
                {esRegistro() ? "¿Ya tienes una cuenta?" : "¿Todavía no tienes cuenta?"}
                <button type={"button"}
                        onClick={() => asignarTipoDeConsola(esRegistro()
                            ? TipoDeConsolaDeAutorización.ACCESO
                            : TipoDeConsolaDeAutorización.REGISTRO)}>
                    {esRegistro() ? "Accede" : "Regístrate"}
                </button>
            </p>
        </div>
    );
}

export default ConsolaDeAutorización;
