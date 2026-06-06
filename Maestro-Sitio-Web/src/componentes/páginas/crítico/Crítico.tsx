import './Crítico.scss';
import type {ReactElement} from "react";
import {useMemo, useState} from "react";
import PromociónDeCrítico from "../../elementos/grupos-elementos-crítico/promoción-de-crítico/PromociónDeCrítico.tsx";
import PanelDeRedacciónCrítico from "../../elementos/grupos-elementos-crítico/panel-de-redacción-crítico/PanelDeRedacciónCrítico.tsx";
import PanelDeResultadoCrítico from "../../elementos/grupos-elementos-crítico/panel-de-resultado-crítico/PanelDeResultadoCrítico.tsx";
import PanelDeSesiónCrítico from "../../elementos/grupos-elementos-crítico/panel-de-sesión-crítico/PanelDeSesiónCrítico.tsx";
import {
    usarAutorización
} from "../../contextos/contexto-de-autorización/ganchos/usarAutorización.ts";
import {
    FocoCrítico, ModoCrítico,
    TarjetaDeResultado
} from "../../../modelos/crítico/tipos.ts";
import {crearResultado} from "../../../guiones/crítico/guiones-crítico.ts";

function Crítico(): ReactElement {
    const {conectado} = usarAutorización();
    const [texto, asignarTexto] = useState("Me gusta mucho esta ciudad porque tiene una historia muy fuerte.");
    const [modo, asignarModo] = useState<ModoCrítico>(ModoCrítico.Natural);
    const [foco, asignarFoco] = useState<FocoCrítico>(FocoCrítico.Todo);
    const [resultado, asignarResultado] = useState<TarjetaDeResultado[]>(
        () => crearResultado(texto, modo, foco)
    );
    const longitud = useMemo(() => texto.trim().length, [texto]);

    if (!conectado) {
        return <PromociónDeCrítico/>;
    }

    function criticar(): void {
        asignarResultado(crearResultado(texto, modo, foco));
    }

    return (
        <div className={"crítico"}>
            <section className={"encabezado-funcional-crítico"}>
                <div>
                    <p className={"ceja-promocional"}>Crítico</p>
                    <h1>Revisa, ajusta y vuelve a intentar.</h1>
                    <p>
                        Un espacio de trabajo para convertir tus borradores en español más natural, preciso
                        y expresivo. Esta vista está lista para conectarse al servicio cuando el backend esté disponible.
                    </p>
                </div>
            </section>

            <main className={"espacio-de-trabajo-crítico"}>
                <PanelDeRedacciónCrítico
                    texto={texto}
                    modo={modo}
                    foco={foco}
                    alCambiarTexto={asignarTexto}
                    alCambiarModo={asignarModo}
                    alCambiarFoco={asignarFoco}
                    alCriticar={criticar}
                />
                <PanelDeResultadoCrítico resultado={resultado}/>
                <PanelDeSesiónCrítico modo={modo} foco={foco} longitud={longitud}/>
            </main>
        </div>
    );
}

export default Crítico;
