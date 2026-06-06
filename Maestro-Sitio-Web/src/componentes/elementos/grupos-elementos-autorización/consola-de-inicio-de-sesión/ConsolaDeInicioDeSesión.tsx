import './ConsolaDeInicioDeSesión.scss';
import {ReactElement} from "react";
import EntradaDeAutorización
    from "../grupos-elementos-entrada/entrada-de-autorización/EntradaDeAutorización.tsx";
import {
    TipoDeEntradaDeAutorización
} from "../grupos-elementos-entrada/entrada-de-autorización/modelos/TipoDeEntradaDeAutorización.ts";
import Botón from "../../grupos-elementos-nativos/botón/Botón.tsx";

function ConsolaDeInicioDeSesión(): ReactElement {
    return (
        <div className={"consola-de-inicio-de-sesión"}>
            <EntradaDeAutorización tipo={TipoDeEntradaDeAutorización.CorreoElectrónico}
                                   enLaEntrada={() => null}/>
            <EntradaDeAutorización tipo={TipoDeEntradaDeAutorización.Contraseña}
                                   enLaEntrada={() => null}/>
            <Botón texto={"Acceso"}/>
            <p className={"nota-de-acceso"}>
                El acceso estará disponible pronto. Por ahora, puedes revisar cómo se verá el inicio de sesión.
            </p>
        </div>
    );
}

export default ConsolaDeInicioDeSesión;
