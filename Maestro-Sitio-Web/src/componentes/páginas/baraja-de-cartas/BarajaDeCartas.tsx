import './BarajaDeCartas.scss';
import {ReactElement, useState} from "react";
import BotónParaCrearBaraja
    from "../../elementos/grupos-elementos-baraja-de-cartas/botón-para-crear-baraja/BotónParaCrearBaraja.tsx";
import MenúParaCrearBaraja
    from "../../elementos/grupos-elementos-baraja-de-cartas/menú-para-crear-baraja/MenúParaCrearBaraja.tsx";
import Tarjeta from "../../elementos/grupos-elementos-baraja-de-cartas/tarjeta/Tarjeta.tsx";
import {TarjetaDidáctica} from "../../../modelos/baraja-de-cartas/tipos.ts";

const tarjetasDeMuestra: TarjetaDidáctica[] = [
    {
        contenidoFrontal: "hablar",
        contenidoPosterior: "to speak"
    },
    {
        contenidoFrontal: "la memoria",
        contenidoPosterior: "memory"
    },
    {
        contenidoFrontal: "escuchar",
        contenidoPosterior: "to listen"
    }
];

function BarajaDeCartas(): ReactElement {
    const [barajaCrearMenúVisible, asignarBarajaCrearMenúVisible] = useState<boolean>(false);

    function manejarClicEnMenú(visible: boolean): void {
        asignarBarajaCrearMenúVisible(visible);
    }

    return (
        <div className={"baraja-de-cartas"}>
            <section className={"encabezado-de-baraja"}>
                <div>
                    <p className={"ceja-promocional"}>Práctica de tarjetas</p>
                    <h1>Baraja de cartas</h1>
                    <p>
                        Organiza vocabulario, repasos y pequeñas pistas en una mesa de estudio
                        limpia, lista para practicar con ritmo.
                    </p>
                </div>
            </section>

            <section className={"espacio-de-baraja"}>
                <div className={"panel-de-acciones-de-baraja"}>
                    <div className={"barra-de-panel-de-baraja"}>
                        <span>Barajas</span>
                        <strong>{barajaCrearMenúVisible ? "Nueva" : "Inicio"}</strong>
                    </div>
                    {!barajaCrearMenúVisible && <BotónParaCrearBaraja alHacerClic={manejarClicEnMenú}/>}
                    {barajaCrearMenúVisible && <MenúParaCrearBaraja alHacerClicEnCerrar={manejarClicEnMenú}/>}
                </div>

                <div className={"panel-de-vista-de-baraja"}>
                    <div className={"barra-de-panel-de-baraja"}>
                        <span>Vista previa</span>
                        <strong>3 tarjetas</strong>
                    </div>
                    <div className={"mesa-de-tarjetas"}>
                        {tarjetasDeMuestra.map((tarjeta: TarjetaDidáctica) => (
                            <Tarjeta key={tarjeta.contenidoFrontal} tarjetaDidáctica={tarjeta}/>
                        ))}
                    </div>
                </div>

                <aside className={"panel-de-sesión-de-baraja"}>
                    <div className={"barra-de-panel-de-baraja"}>
                        <span>Sesión</span>
                        <strong>Repaso</strong>
                    </div>
                    <article>
                        <span>Pendientes</span>
                        <strong>12</strong>
                    </article>
                    <article>
                        <span>Dominadas</span>
                        <strong>8</strong>
                    </article>
                    <div className={"nota-de-sesión-de-baraja"}>
                        <strong>Consejo</strong>
                        <p>Haz clic en una tarjeta para voltearla y revisar el reverso.</p>
                    </div>
                </aside>
            </section>
        </div>
    );
}

export default BarajaDeCartas;
