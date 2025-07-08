import './Tarjeta.scss';
import {ReactElement, useState} from "react";
import Título from "../../grupos-elementos-texto/título/Título.tsx";
import {TipoDeEtiqueta} from "../../../../modelos/html/TipoDeEtiqueta.ts";
import {
    TarjetaDidáctica
} from "../../../../modelos/baraja-de-cartas/tipos.ts";

interface PropsTarjeta {
    tarjetaDidáctica: TarjetaDidáctica
}

function Tarjeta(props: PropsTarjeta): ReactElement {
    const [estáVolteado, asignarEstáVolteado] = useState<boolean>(false);

    function obtenerClasesBase(): string {
        let clases: string = "tarjeta";
        if (estáVolteado) {
            clases += " volteado";
        }
        return clases;
    }

    function palancaVolteada(): void {
        asignarEstáVolteado(!estáVolteado);
    }

    return (
        <div className={obtenerClasesBase()} onClick={palancaVolteada}>
            <div className={"envoltura-de-perspectiva"}>
                <div className={"contenido-frontal"}>
                    <Título texto={props.tarjetaDidáctica.contenidoFrontal}
                            tipoDeEtiqueta={TipoDeEtiqueta.H3}/>
                </div>
                <div className={"contenido-posterior"}>
                    <Título texto={props.tarjetaDidáctica.contenidoPosterior}
                            tipoDeEtiqueta={TipoDeEtiqueta.H3}/>
                </div>
            </div>
        </div>
    );
}

export default Tarjeta;