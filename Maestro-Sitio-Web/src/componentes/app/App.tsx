// App.tsx
import {
    ProveedorDeAutorización
} from "../contextos/contexto-de-autorización/ContextoDeAutorización.tsx";
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
import Autorización from "../páginas/autorización/Autorización.tsx";
import AutorizaciónRutaProtegida
    from "../elementos/grupos-elementos-autorización/autorización-ruta-protegida/AutorizaciónRutaProtegida.tsx";
import Panel from "../páginas/panel/Panel.tsx";

function App(): ReactElement {
    return (
        <div className={"app"}>
            <Router>
                <ProveedorDeAutorización>
                    <BarraDeNav/>
                    <Routes>
                        <Route path={"/"} element={<Casa/>}/>
                        <Route path={"/conj"} element={<Conjugador/>}/>
                        <Route path={"/baraja-de-cartas"} element={<BarajaDeCartas/>}/>
                        <Route path={"/cuenta"} element={
                            <AutorizaciónRutaProtegida>
                                <AnclaDeCuenta/>
                            </AutorizaciónRutaProtegida>
                        }/>
                        <Route path={"/autorización"} element={<Autorización/>}/>
                        <Route path={"/panel"} element={
                            <AutorizaciónRutaProtegida>
                                <Panel/>
                            </AutorizaciónRutaProtegida>
                        }/>
                    </Routes>
                </ProveedorDeAutorización>
            </Router>
        </div>
    );
}

export default App