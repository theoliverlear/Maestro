import './MenúDesplegableDeNav.scss';
import {ReactElement, useEffect, useState} from "react";
import {
    EnlaceDeElemento, EnlaceDeElementoDesplegableVinculado
} from "../../../../activos/activosDeEnlaceDeElementos.ts";
import ElementoDeNav from "../elemento-de-nav/ElementoDeNav.tsx";

interface PropsMenúDesplegableDeNav {
    enlaceDelElementoDesplegable: EnlaceDeElementoDesplegableVinculado;
}

function MenúDesplegableDeNav(props: PropsMenúDesplegableDeNav): ReactElement {
    const [menúDesplegableActivo, asignarMenúDesplegableActivo] = useState<boolean>(false);

    return (
        <div className={"menú-desplegable-de-nav"} onMouseOver={() => asignarMenúDesplegableActivo(true)} onMouseLeave={() => asignarMenúDesplegableActivo(false)}>
            <ElementoDeNav enlaceDeElemento={props.enlaceDelElementoDesplegable.enlaceDelTítulo}
                           esDesplegable={true}/>
            <div className={"elementos-ocultos"}>
                {menúDesplegableActivo && <div className={"lista-de-elementos"}>
                    {menúDesplegableActivo &&
                        props.enlaceDelElementoDesplegable.enlacesDeElemento.map((enlace: EnlaceDeElemento) => {
                            return <ElementoDeNav enlaceDeElemento={enlace}
                                                  key={enlace.texto}/>;
                        })
                    }
                </div>}
            </div>
        </div>
    );
}

export default MenúDesplegableDeNav;