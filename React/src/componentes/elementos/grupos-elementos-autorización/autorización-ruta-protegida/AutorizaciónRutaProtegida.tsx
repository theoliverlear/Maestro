import {JSX} from "react";
import {Navigate, useLocation} from "react-router-dom";
import {
    usarAutorización
} from "../../../contextos/contexto-de-autorización/ContextoDeAutorización.tsx";

interface PropsAutorizaciónRutaProtegida {
    children: JSX.Element;
}

function AutorizaciónRutaProtegida({ children }: PropsAutorizaciónRutaProtegida) {
    const { conectado } = usarAutorización();
    const { pathname } = useLocation();

    if (!conectado) {
        return <Navigate to={`/autorización?redir=${encodeURIComponent(pathname)}`} replace/>;
    }
    return children;
}

export default AutorizaciónRutaProtegida;