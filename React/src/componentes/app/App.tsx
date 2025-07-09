import './App.scss';
import type {ReactElement} from "react";
import {Route, BrowserRouter as Router, Routes} from "react-router-dom";
import Casa from "../páginas/casa/Casa.tsx";
import Conjugador from "../páginas/conjugador/Conjugador.tsx";
import BarraDeNav
    from "../elementos/grupos-elementos-nav/barra-de-nav/BarraDeNav.tsx";
import BarajaDeCartas from "../páginas/baraja-de-cartas/BarajaDeCartas.tsx";
import AnclaDeCuenta
    from "../elementos/grupos-elementos-nav/ancla-de-cuenta/AnclaDeCuenta.tsx";

function App(): ReactElement {
    return (
        <div className={"app"}>
            <Router>
                <BarraDeNav/>
                <Routes>
                    <Route path={"/"} element={<Casa/>}/>
                    <Route path={"/conj"} element={<Conjugador/>}/>
                    <Route path={"/baraja-de-cartas"} element={<BarajaDeCartas/>}/>
                    <Route path={"/cuenta"} element={<AnclaDeCuenta/>}/>
                </Routes>
            </Router>
        </div>
    );
}

export default App