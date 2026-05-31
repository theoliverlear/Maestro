// MenúParaCrearBaraja.tsx
import './MenúParaCrearBaraja.scss';
import Botón from "../../grupos-elementos-nativos/botón/Botón.tsx";
import Título from "../../grupos-elementos-texto/título/Título.tsx";
import {TipoDeEtiqueta} from "../../../../modelos/html/TipoDeEtiqueta.ts";
import EntradaConTítulo
    from "../../grupos-elementos-entrada/entrada-con-título/EntradaConTítulo.tsx";
import {
    TipoDeEntrada
} from "../../grupos-elementos-nativos/entrada/modelos/TipoDeEntrada.ts";
import {
    recursoDeImagenDeIconoDeCerrarBlanco

} from "../../../../activos/recursosDeImagen.ts";

interface PropsMenúParaCrearBaraja {
    alHacerClicEnCerrar: (visible: boolean) => void;
}

function MenúParaCrearBaraja(props: PropsMenúParaCrearBaraja) {
    return (
        <div className={"menú-para-crear-baraja"}>
            <div className={"línea-superior"}>
                <Botón nombreClase={"botón-de-cerrar"}
                       recursoDeImagen={recursoDeImagenDeIconoDeCerrarBlanco}
                       alHacerClic={() => props.alHacerClicEnCerrar(false)}/>
                <Título nombreClase={"título-del-menú"}
                        texto={"Creat Baraja de Tarjetas"}
                        tipoDeEtiqueta={TipoDeEtiqueta.H4}/>
            </div>

            <div className={"entradas-de-menú"}>
                <EntradaConTítulo textoDelTítulo={"Título: "}
                                  tipoDeEtiqueta={TipoDeEtiqueta.H4}
                                  tipoDeEntrada={TipoDeEntrada.TEXTO}
                                  enLaEntrada={() => null}/>
            </div>
            <Botón texto={"Crear"}/>
        </div>
    );
}
export default MenúParaCrearBaraja;