import './Imagen.scss';
import {ReactElement} from "react";
import {RecursoDeImagen} from "../../../../activos/recursosDeImagen.ts";

interface PropsImagen {
    recursoDeImagen: RecursoDeImagen;
}

function Imagen(props: PropsImagen): ReactElement {
    return (
        <div className={"imagen"}>
            <img src={props.recursoDeImagen.src}
                 alt={props.recursoDeImagen.alt}
                 draggable={false}/>
        </div>
    );
}

export default Imagen;