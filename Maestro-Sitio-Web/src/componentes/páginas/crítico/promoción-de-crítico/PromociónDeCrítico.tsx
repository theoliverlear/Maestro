import './PromociónDeCrítico.scss';
import type {ReactElement} from "react";
import {Link} from "react-router-dom";

type PuntoDeCrítica = {
    título: string;
    texto: string;
};

type ModoDeCrítica = PuntoDeCrítica & {
    etiqueta: string;
};

type PasoDeCrítica = PuntoDeCrítica & {
    número: string;
};

const modosDeCrítica: ModoDeCrítica[] = [
    {
        etiqueta: "Formal",
        título: "Claridad profesional",
        texto: "Ajusta tono, registro y precisión para mensajes académicos, laborales o públicos."
    },
    {
        etiqueta: "Natural",
        título: "Español idiomático",
        texto: "Detecta frases literales y propone alternativas más fluidas para conversaciones reales."
    },
    {
        etiqueta: "Cultural",
        título: "Contexto con matiz",
        texto: "Sugiere detalles, ejemplos y giros que hacen que la respuesta suene situada, no genérica."
    }
];

const resultadosDeEjemplo: PuntoDeCrítica[] = [
    {
        título: "Elogio",
        texto: "La intención comunicativa se entiende y la estructura causa-consecuencia está bien encaminada."
    },
    {
        título: "Crítica",
        texto: "La expresión \"historia muy fuerte\" puede sonar literal; conviene elegir una imagen más precisa."
    },
    {
        título: "Mejora",
        texto: "Prueba con: \"Me gusta esta ciudad porque tiene una historia muy rica y todavía se nota en sus barrios.\""
    }
];

const pasosDeCrítica: PasoDeCrítica[] = [
    {
        número: "01",
        título: "Escribe con intención",
        texto: "Parte de una frase, un párrafo o una respuesta completa con un objetivo comunicativo claro."
    },
    {
        número: "02",
        título: "Recibe juicio separado",
        texto: "Revisa elogio, crítica, corrección y mejora sin mezclar gramática, estilo y contenido."
    },
    {
        número: "03",
        título: "Reintenta con criterio",
        texto: "Usa la versión sugerida como andamio y vuelve a escribir con más precisión y naturalidad."
    }
];

function PanelDeEntradaPromocional(): ReactElement {
    return (
        <div className={"panel-de-entrada-crítico"}>
            <div className={"barra-de-panel-crítico"}>
                <span>Borrador</span>
                <strong>Español escrito</strong>
            </div>
            <label htmlFor={"entrada-promocional-crítico"}>Tu intento</label>
            <textarea
                id={"entrada-promocional-crítico"}
                value={"Me gusta mucho esta ciudad porque tiene una historia muy fuerte."}
                readOnly
            />
            <div className={"controles-de-crítico"}>
                <button type={"button"} className={"activo"}>Natural</button>
                <button type={"button"}>Formal</button>
                <button type={"button"}>Cultural</button>
            </div>
        </div>
    );
}

function ResultadoPromocional(): ReactElement {
    return (
        <div className={"resultado-de-crítico"}>
            <div className={"barra-de-panel-crítico"}>
                <span>Respuesta</span>
                <strong>Crítica guiada</strong>
            </div>
            {resultadosDeEjemplo.map((resultado: PuntoDeCrítica) => (
                <article key={resultado.título}>
                    <strong>{resultado.título}</strong>
                    <p>{resultado.texto}</p>
                </article>
            ))}
        </div>
    );
}

function MesaPromocional(): ReactElement {
    return (
        <section className={"mesa-de-trabajo-crítico"}>
            <div className={"encabezado-de-crítico"}>
                <p className={"ceja-promocional"}>Crítico</p>
                <h1>Convierte cada intento en una lección.</h1>
                <p>
                    Escribe en español y recibe una revisión separada por elogio, crítica, corrección y
                    mejora. La meta es ayudarte a sonar más claro, natural y situado.
                </p>
            </div>

            <div className={"consola-de-crítico"} aria-label={"Vista de trabajo de Crítico"}>
                <PanelDeEntradaPromocional/>
                <ResultadoPromocional/>
            </div>
        </section>
    );
}

function ModosDeCrítica(): ReactElement {
    return (
        <section className={"sección-de-modos-crítico"}>
            <div className={"encabezado-de-sección"}>
                <p className={"ceja-promocional"}>Perfiles</p>
                <h2>La crítica cambia según el contexto.</h2>
            </div>
            <div className={"cuadrícula-de-modos-crítico"}>
                {modosDeCrítica.map((modo: ModoDeCrítica) => (
                    <article className={"modo-de-crítica"} key={modo.título}>
                        <span>{modo.etiqueta}</span>
                        <h3>{modo.título}</h3>
                        <p>{modo.texto}</p>
                    </article>
                ))}
            </div>
        </section>
    );
}

function AnatomíaDeRespuesta(): ReactElement {
    return (
        <section className={"anatomía-de-respuesta"}>
            <div>
                <p className={"ceja-promocional"}>Respuesta estructurada</p>
                <h2>Primero entiende qué funciona. Luego corrige lo que falta.</h2>
            </div>
            <div className={"lista-de-capas-crítico"}>
                <article>
                    <strong>Forma</strong>
                    <p>Gramática, concordancia, orden de palabras y puntuación.</p>
                </article>
                <article>
                    <strong>Estilo</strong>
                    <p>Registro, fluidez, elección léxica y naturalidad.</p>
                </article>
                <article>
                    <strong>Contenido</strong>
                    <p>Precisión, fuerza del argumento y detalles culturales útiles.</p>
                </article>
            </div>
        </section>
    );
}

function RutaDeCrítica(): ReactElement {
    return (
        <section className={"ruta-de-crítica"}>
            <div className={"encabezado-de-sección"}>
                <p className={"ceja-promocional"}>Flujo de práctica</p>
                <h2>Un ciclo corto para escribir mejor.</h2>
            </div>
            <div className={"pasos-de-crítica"}>
                {pasosDeCrítica.map((paso: PasoDeCrítica) => (
                    <article key={paso.título}>
                        <span>{paso.número}</span>
                        <h3>{paso.título}</h3>
                        <p>{paso.texto}</p>
                    </article>
                ))}
            </div>
        </section>
    );
}

function PromociónDeCrítico(): ReactElement {
    return (
        <div className={"promoción-de-crítico"}>
            <MesaPromocional/>
            <ModosDeCrítica/>
            <AnatomíaDeRespuesta/>
            <RutaDeCrítica/>
            <section className={"cta-de-crítico"}>
                <div>
                    <p className={"ceja-promocional"}>Empieza a practicar</p>
                    <h2>Crea una cuenta para usar Crítico con tus propios textos.</h2>
                </div>
                <Link to={"/autorización?redir=%2Fcr%C3%ADtico"} className={"botón-promocional"}>Crear cuenta</Link>
            </section>
        </div>
    );
}

export default PromociónDeCrítico;
