import './Crítico.scss';
import type {ReactElement} from "react";
import {useMemo, useState} from "react";
import {usarAutorización} from "../../contextos/contexto-de-autorización/ContextoDeAutorización.tsx";
import PromociónDeCrítico from "./promoción-de-crítico/PromociónDeCrítico.tsx";

type ModoCrítico = "natural" | "formal" | "cultural" | "directo";
type FocoCrítico = "todo" | "gramática" | "estilo" | "contenido";

type OpciónCrítico<T extends string> = {
    valor: T;
    etiqueta: string;
};

type TarjetaDeResultado = {
    título: string;
    texto: string;
};

const modos: OpciónCrítico<ModoCrítico>[] = [
    {valor: "natural", etiqueta: "Natural"},
    {valor: "formal", etiqueta: "Formal"},
    {valor: "cultural", etiqueta: "Cultural"},
    {valor: "directo", etiqueta: "Directo"}
];

const focos: OpciónCrítico<FocoCrítico>[] = [
    {valor: "todo", etiqueta: "Todo"},
    {valor: "gramática", etiqueta: "Gramática"},
    {valor: "estilo", etiqueta: "Estilo"},
    {valor: "contenido", etiqueta: "Contenido"}
];

function crearResultado(texto: string, modo: ModoCrítico, foco: FocoCrítico): TarjetaDeResultado[] {
    const entrada = texto.trim();
    const frase = entrada.length > 0 ? entrada : "Escribe un intento para recibir crítica.";
    return [
        {
            título: "Elogio",
            texto: "La intención principal se entiende. Hay una base clara para mejorar sin reescribir todo desde cero."
        },
        {
            título: "Crítica",
            texto: `Modo ${modo}, foco ${foco}: revisa precisión, naturalidad y fuerza expresiva en "${frase}".`
        },
        {
            título: "Versión sugerida",
            texto: "Me gusta esta ciudad porque tiene una historia muy rica, y todavía se nota en sus barrios, su arquitectura y sus tradiciones."
        },
        {
            título: "Siguiente intento",
            texto: "Reescribe la frase agregando un detalle concreto. Busca una imagen precisa antes de usar intensificadores como \"muy\"."
        }
    ];
}

function SelectorSegmentado<T extends string>(props: {
    opciones: OpciónCrítico<T>[];
    valor: T;
    alCambiar: (valor: T) => void;
}): ReactElement {
    return (
        <div className={"selector-segmentado-crítico"}>
            {props.opciones.map((opción: OpciónCrítico<T>) => (
                <button
                    key={opción.valor}
                    type={"button"}
                    className={props.valor === opción.valor ? "activo" : ""}
                    onClick={() => props.alCambiar(opción.valor)}>
                    {opción.etiqueta}
                </button>
            ))}
        </div>
    );
}

function PanelDeRedacción(props: {
    texto: string;
    modo: ModoCrítico;
    foco: FocoCrítico;
    alCambiarTexto: (valor: string) => void;
    alCambiarModo: (valor: ModoCrítico) => void;
    alCambiarFoco: (valor: FocoCrítico) => void;
    alCriticar: () => void;
}): ReactElement {
    return (
        <section className={"panel-de-redacción-crítico"}>
            <div className={"barra-de-panel-crítico"}>
                <span>Entrada</span>
                <strong>Borrador activo</strong>
            </div>
            <label htmlFor={"texto-para-crítico"}>Texto para criticar</label>
            <textarea
                id={"texto-para-crítico"}
                value={props.texto}
                onChange={evento => props.alCambiarTexto(evento.target.value)}
            />
            <div className={"grupo-de-controles-crítico"}>
                <div>
                    <span>Modo</span>
                    <SelectorSegmentado opciones={modos} valor={props.modo} alCambiar={props.alCambiarModo}/>
                </div>
                <div>
                    <span>Foco</span>
                    <SelectorSegmentado opciones={focos} valor={props.foco} alCambiar={props.alCambiarFoco}/>
                </div>
            </div>
            <button type={"button"} className={"botón-principal-crítico"} onClick={props.alCriticar}>
                Criticar texto
            </button>
        </section>
    );
}

function PanelDeResultado(props: {resultado: TarjetaDeResultado[]}): ReactElement {
    return (
        <section className={"panel-de-resultado-crítico"}>
            <div className={"barra-de-panel-crítico"}>
                <span>Salida</span>
                <strong>Crítica estructurada</strong>
            </div>
            <div className={"tarjetas-de-resultado-crítico"}>
                {props.resultado.map((tarjeta: TarjetaDeResultado) => (
                    <article key={tarjeta.título}>
                        <strong>{tarjeta.título}</strong>
                        <p>{tarjeta.texto}</p>
                    </article>
                ))}
            </div>
        </section>
    );
}

function PanelDeSesiónCrítico(props: {
    modo: ModoCrítico;
    foco: FocoCrítico;
    longitud: number;
}): ReactElement {
    return (
        <aside className={"panel-de-sesión-crítico"}>
            <div className={"barra-de-panel-crítico"}>
                <span>Sesión</span>
                <strong>Preparada</strong>
            </div>
            <article>
                <span>Modo</span>
                <strong>{props.modo}</strong>
            </article>
            <article>
                <span>Foco</span>
                <strong>{props.foco}</strong>
            </article>
            <article>
                <span>Extensión</span>
                <strong>{props.longitud} caracteres</strong>
            </article>
            <div className={"nota-de-sesión-crítico"}>
                <strong>Consejo</strong>
                <p>Una buena crítica necesita intención: explica qué querías decir, no solo qué escribiste.</p>
            </div>
        </aside>
    );
}

function Crítico(): ReactElement {
    const {conectado} = usarAutorización();
    const [texto, asignarTexto] = useState("Me gusta mucho esta ciudad porque tiene una historia muy fuerte.");
    const [modo, asignarModo] = useState<ModoCrítico>("natural");
    const [foco, asignarFoco] = useState<FocoCrítico>("todo");
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
                <PanelDeRedacción
                    texto={texto}
                    modo={modo}
                    foco={foco}
                    alCambiarTexto={asignarTexto}
                    alCambiarModo={asignarModo}
                    alCambiarFoco={asignarFoco}
                    alCriticar={criticar}
                />
                <PanelDeResultado resultado={resultado}/>
                <PanelDeSesiónCrítico modo={modo} foco={foco} longitud={longitud}/>
            </main>
        </div>
    );
}

export default Crítico;
