import './AnatomíaDeRespuesta.scss';
import type {ReactElement} from "react";

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

export default AnatomíaDeRespuesta;

