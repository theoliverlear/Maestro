import './App.scss';
import type {ReactElement} from "react";
import {Route, BrowserRouter as Router, Routes} from "react-router-dom";
import Casa from "../páginas/casa/Casa.tsx";
import Conjugación from "../páginas/conjugación/Conjugación.tsx";
import BarraDeNav
    from "../elementos/grupos-elementos-nav/barra-de-nav/BarraDeNav.tsx";

function App(): ReactElement {
    return (
        <div className={"app"}>
            <BarraDeNav/>
            <Router>
                <Routes>
                    <Route path={"/"} element={<Casa/>}/>
                    <Route path={"/conj"} element={<Conjugación/>}/>
                </Routes>
            </Router>
        </div>
    );
}

export default App