import './PromociónDeCrítico.scss';
import type {ReactElement} from "react";
import MesaPromocional from "./mesa-promocional/MesaPromocional.tsx";
import ModosDeCrítica from "./modos-de-crítica/ModosDeCrítica.tsx";
import AnatomíaDeRespuesta from "./anatomía-de-respuesta/AnatomíaDeRespuesta.tsx";
import RutaDeCrítica from "./ruta-de-crítica/RutaDeCrítica.tsx";
import CtaDeCrítico from "./cta-de-crítico/CtaDeCrítico.tsx";

function PromociónDeCrítico(): ReactElement {
    return (
        <div className={"promoción-de-crítico"}>
            <MesaPromocional/>
            <ModosDeCrítica/>
            <AnatomíaDeRespuesta/>
            <RutaDeCrítica/>
            <CtaDeCrítico/>
        </div>
    );
}

export default PromociónDeCrítico;

