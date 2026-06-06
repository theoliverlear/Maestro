import './EntradasDeRegistro.scss';
import {ReactElement, useEffect, useState} from "react";
import EntradaDeAutorización
    from "../entrada-de-autorización/EntradaDeAutorización.tsx";
import {
    TipoDeEntradaDeAutorización
} from "../entrada-de-autorización/modelos/TipoDeEntradaDeAutorización.ts";
import Título from "../../../grupos-elementos-texto/título/Título.tsx";
import {TipoDeEtiqueta} from "../../../../../modelos/html/TipoDeEtiqueta.ts";
import Botón from "../../../grupos-elementos-nativos/botón/Botón.tsx";
import {
    GenSolicitudDeRegistro
} from "../../../../../modelos/autorización/GenSolicitudDeRegistro.ts";
import {
    EstadosDeValidezDeAutorización
} from "../../modelos/EstadosDeValidezDeAutorización.ts";
import {
    usarEntradasDeRegistro
} from "../../../../../ganchos/usarEntradasDeRegistro.ts";

interface PropsEntradasDeRegistro {
    cambioPetición: (solicitud: GenSolicitudDeRegistro) => void;
    sobreCambioDeMensaje: (mensaje: EstadosDeValidezDeAutorización) => void;
    alEnviar: (éxito: boolean, solicitud: GenSolicitudDeRegistro) => void;
}

function EntradasDeRegistro(props: PropsEntradasDeRegistro): ReactElement {
    const { solicitud, mensaje, manipuladores } = usarEntradasDeRegistro();

    useEffect(() => {
        props.cambioPetición(solicitud);
    }, [props.cambioPetición, solicitud]);

    useEffect(() => {
        props.sobreCambioDeMensaje(mensaje);
    }, [props.sobreCambioDeMensaje, mensaje]);

    return (
        <div className={"entradas-de-registro"}>
            <Título texto={"Registro"} tipoDeEtiqueta={TipoDeEtiqueta.H3}/>
            <EntradaDeAutorización tipo={TipoDeEntradaDeAutorización.CorreoElectrónico}
                                   enLaEntrada={manipuladores.manejarCorreoElectrónico}/>
            <EntradaDeAutorización tipo={TipoDeEntradaDeAutorización.Contraseña}
                                   enLaEntrada={manipuladores.manejarContraseña}/>
            <EntradaDeAutorización tipo={TipoDeEntradaDeAutorización.ConfirmarContraseña}
                                   enLaEntrada={manipuladores.manejarConfirmarContraseña}/>
            <Botón texto={"Registro"} alHacerClic={() => props.alEnviar(manipuladores.manejarEnvío(), solicitud)}/>
        </div>
    );
}

export default EntradasDeRegistro;
