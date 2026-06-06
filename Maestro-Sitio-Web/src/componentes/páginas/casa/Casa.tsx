import './Casa.scss';
import type {ReactElement} from "react";
import {Link} from "react-router-dom";
import Imagen from "../../elementos/grupos-elementos-nativos/imagen/Imagen.tsx";
import {recursoDeImagenDelLogotipoTransparente} from "../../../activos/RecursosDeImagen.activos.ts";

// TODO: Extraer a archivo de tipo.
type PuntoPromocional = {
    título: string;
    texto: string;
};
// TODO: Extraer a archivo de tipo.
type HerramientaPromocional = PuntoPromocional & {
    enlace: string;
    etiqueta: string;
};
// TODO: Extraer a archivo de activos.
const puntosDeValor: PuntoPromocional[] = [
    {
        título: "Aprendizaje profundo",
        texto: "Práctica que no se queda en memorizar: forma, significado, estilo y contexto cultural."
    },
    {
        título: "Corrección con criterio",
        texto: "Retroalimentación pensada para explicar por qué una frase funciona, no solo si está bien."
    },
    {
        título: "Inmersión asistida",
        texto: "Ayudas rápidas para leer, escribir y entender español sin salir del flujo de estudio."
    }
];
// TODO: Extraer a archivo de activos.
const herramientas: HerramientaPromocional[] = [
    {
        título: "Crítico",
        texto: "El producto estrella: escribe o habla y recibe elogios, correcciones y crítica de estilo, sintaxis y contenido.",
        enlace: "/crítico",
        etiqueta: "Abrir Crítico"
    },
    {
        título: "Conjugador",
        texto: "Practica verbos, tiempos y pronombres con respuestas inmediatas.",
        enlace: "/conj",
        etiqueta: "Abrir conjugador"
    },
    {
        título: "Baraja de cartas",
        texto: "Crea repasos de vocabulario y conceptos para sesiones rápidas.",
        enlace: "/baraja-de-cartas",
        etiqueta: "Crear baraja"
    },
    {
        título: "Panel",
        texto: "Reúne la actividad de estudio y conserva el camino de aprendizaje.",
        enlace: "/panel",
        etiqueta: "Ver panel"
    },
    {
        título: "Ojeada",
        texto: "Un ayudante siempre disponible para pasar cualquier texto del sitio a su traducción en inglés.",
        enlace: "/autorización",
        etiqueta: "Conocer helper"
    }
];
// TODO: Extraer a archivo de activos.
const pasosDeAprendizaje: PuntoPromocional[] = [
    {
        título: "Recibe entrada real",
        texto: "Lee, escucha, escribe o habla con objetivos concretos."
    },
    {
        título: "Entiende el porqué",
        texto: "Revisa correcciones sobre gramática, tono, precisión y naturalidad."
    },
    {
        título: "Refina tu español",
        texto: "Vuelve a intentar con una versión más idiomática, clara y culturalmente situada."
    }
];

function Casa(): ReactElement {
    // TODO: Extraer texto a archivo de texto.
    return (
        <div className={"casa"}>
            <section className={"sección-hero-casa"}>
                <div className={"columna-de-copy-hero"}>
                    <p className={"ceja-promocional"}>Español práctico, hecho para volver cada día</p>
                    <h1>Maestro</h1>
                    <p className={"texto-principal-hero"}>
                        Una plataforma de aprendizaje profundo para practicar español, recibir crítica útil
                        y avanzar desde ejercicios básicos hasta expresión natural con contexto cultural.
                    </p>
                    <div className={"fila-de-acciones-hero"}>
                        <Link to={"/autorización"} className={"botón-promocional primario"}>
                            Empezar ahora
                        </Link>
                        <a href={"#critico"} className={"botón-promocional secundario"}>
                            Ver Crítico
                        </a>
                    </div>
                </div>

                <div className={"visual-hero"} aria-label={"Vista promocional de Maestro"}>
                    <div className={"marca-de-agua"}>
                        <Imagen recursoDeImagen={recursoDeImagenDelLogotipoTransparente}/>
                    </div>
                    <div className={"panel-de-práctica crítico"}>
                        <span className={"etiqueta-de-panel"}>Crítico</span>
                        <h2>Tu español, con revisión experta</h2>
                        <div className={"burbuja-de-entrada"}>
                            Quiero explicar mi opinión con más elegancia.
                        </div>
                        <div className={"fila-de-ejercicio activa"}>
                            <span>estilo</span>
                            <strong>más natural</strong>
                        </div>
                        <div className={"fila-de-ejercicio"}>
                            <span>sintaxis</span>
                            <strong>clara</strong>
                        </div>
                        <div className={"fila-de-ejercicio"}>
                            <span>cultura</span>
                            <strong>con matiz</strong>
                        </div>
                    </div>
                </div>
            </section>

            <section className={"sección-critico"} id={"critico"}>
                <div className={"copy-de-critico"}>
                    <p className={"ceja-promocional"}>Producto estrella</p>
                    <h2>Crítico convierte cada intento en una lección.</h2>
                    <p>
                        Escribe o habla en español y recibe una respuesta que separa elogio, crítica y
                        mejora. Maestro revisa estilo, sintaxis, precisión, contenido y naturalidad para que
                        cada frase sea una oportunidad de aprendizaje real.
                    </p>
                </div>

                <div className={"panel-de-crítica"}>
                    <div className={"entrada-crítico"}>
                        <span>Tu intento</span>
                        <p>Me gusta mucho esta ciudad porque tiene una historia muy fuerte.</p>
                    </div>
                    <div className={"resultado-crítico"}>
                        <article>
                            <strong>Elogio</strong>
                            <p>La idea central es clara y la causa está bien conectada.</p>
                        </article>
                        <article>
                            <strong>Crítica</strong>
                            <p>"Historia muy fuerte" puede sonar literal; "historia muy rica" es más natural.</p>
                        </article>
                        <article>
                            <strong>Mejora cultural</strong>
                            <p>Añade un ejemplo concreto: arquitectura, barrio, comida o tradición local.</p>
                        </article>
                    </div>
                </div>
            </section>

            <section className={"sección-ojeada"}>
                <div className={"tarjeta-ojeada"}>
                    <p className={"ceja-promocional"}>Ayuda en cualquier parte</p>
                    <h2>Ojeada traduce el sitio cuando necesitas un vistazo.</h2>
                    <p>
                        Haz clic en el ayudante Ojeada desde cualquier lugar de Maestro y las palabras se
                        deslizan hacia su traducción en inglés. Es una ayuda rápida para recuperar contexto
                        sin abandonar la inmersión.
                    </p>
                </div>

                <div className={"demostración-ojeada"}>
                    <div className={"línea-ojeada español"}>
                        <span>El aprendizaje profundo necesita contexto.</span>
                    </div>
                    <div className={"deslizador-ojeada"}/>
                    <div className={"línea-ojeada inglés"}>
                        <span>Deep learning needs context.</span>
                    </div>
                </div>
            </section>

            <section className={"sección-hero-casa compacta"}>
                <div className={"columna-de-copy-hero"}>
                    <p className={"ceja-promocional"}>Práctica estructurada</p>
                    <h2>Lo básico sigue importando.</h2>
                    <p className={"texto-principal-hero"}>
                        Crítica inteligente funciona mejor cuando se apoya en fundamentos: verbos,
                        vocabulario, repetición y seguimiento del progreso.
                    </p>
                    <div className={"fila-de-acciones-hero"}>
                        <Link to={"/conj"} className={"botón-promocional primario"}>
                            Probar conjugador
                        </Link>
                    </div>
                </div>

                <div className={"visual-hero"} aria-label={"Vista promocional de Maestro"}>
                    <div className={"marca-de-agua"}>
                        <Imagen recursoDeImagen={recursoDeImagenDelLogotipoTransparente}/>
                    </div>
                    <div className={"panel-de-práctica"}>
                        <span className={"etiqueta-de-panel"}>Sesión de hoy</span>
                        <h2>Practica el presente</h2>
                        <div className={"fila-de-ejercicio"}>
                            <span>yo</span>
                            <strong>hablo</strong>
                        </div>
                        <div className={"fila-de-ejercicio activa"}>
                            <span>nosotros</span>
                            <strong>aprendemos</strong>
                        </div>
                        <div className={"fila-de-ejercicio"}>
                            <span>ellos</span>
                            <strong>viven</strong>
                        </div>
                    </div>
                </div>
            </section>

            <section className={"franja-de-valor"}>
                {puntosDeValor.map((punto: PuntoPromocional) => (
                    <article className={"punto-de-valor"} key={punto.título}>
                        <h2>{punto.título}</h2>
                        <p>{punto.texto}</p>
                    </article>
                ))}
            </section>

            <section className={"sección-promocional clara"}>
                <div className={"encabezado-de-sección"}>
                    <p className={"ceja-promocional"}>Herramientas principales</p>
                    <h2>Herramientas para estudiar con profundidad.</h2>
                    <p>
                        Maestro combina fundamento, crítica y asistencia contextual: abrir, practicar,
                        recibir retroalimentación, guardar progreso y volver con más precisión.
                    </p>
                </div>

                <div className={"cuadrícula-de-herramientas"}>
                    {herramientas.map((herramienta: HerramientaPromocional) => (
                        <article className={"tarjeta-de-herramienta"} key={herramienta.título}>
                            <div className={"acento-de-tarjeta"}/>
                            <h3>{herramienta.título}</h3>
                            <p>{herramienta.texto}</p>
                            <Link to={herramienta.enlace}>{herramienta.etiqueta}</Link>
                        </article>
                    ))}
                </div>
            </section>

            <section className={"sección-promocional ruta"}>
                <div className={"encabezado-de-sección"}>
                    <p className={"ceja-promocional"}>Aprendizaje en profundidad</p>
                    <h2>De la práctica puntual a la expresión con criterio.</h2>
                </div>

                <div className={"pasos-de-aprendizaje"}>
                    {pasosDeAprendizaje.map((paso: PuntoPromocional, índice: number) => (
                        <article className={"paso-de-aprendizaje"} key={paso.título}>
                            <span>{String(índice + 1).padStart(2, "0")}</span>
                            <h3>{paso.título}</h3>
                            <p>{paso.texto}</p>
                        </article>
                    ))}
                </div>
            </section>

            <section className={"cta-final-casa"}>
                <div>
                    <p className={"ceja-promocional"}>Listo para practicar</p>
                    <h2>Empieza con una sesión corta y deja que Maestro convierta cada intento en una lección.</h2>
                </div>
                <Link to={"/autorización"} className={"botón-promocional primario"}>
                    Crear cuenta
                </Link>
            </section>
        </div>
    );
}

export default Casa;
