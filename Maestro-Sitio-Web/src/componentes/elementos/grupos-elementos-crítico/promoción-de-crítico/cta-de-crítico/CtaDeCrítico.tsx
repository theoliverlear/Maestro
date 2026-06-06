import './CtaDeCrítico.scss';
import type {ReactElement} from "react";
import {Link} from "react-router-dom";

function CtaDeCrítico(): ReactElement {
    return (
        <section className={"cta-de-crítico"}>
            <div>
                <p className={"ceja-promocional"}>Empieza a practicar</p>
                <h2>Crea una cuenta para usar Crítico con tus propios textos.</h2>
            </div>
            <Link to={"/autorización?redir=%2Fcr%C3%ADtico"} className={"botón-promocional"}>Crear cuenta</Link>
        </section>
    );
}

export default CtaDeCrítico;

