// ContextoDeAutorización.tsx

import {
    createContext,
    ReactNode,
    useContext,
    useEffect,
    useMemo
} from "react";
import {PosibleIContextoDeAutorización} from "./modelos/tipos.ts";
import {usarConectado} from "../../../manos/usarConectado.ts";

export interface IContextoDeAutorización {
    conectado: boolean;
    refrescar: () => Promise<void>;
}

const ContextoDeAutorización = createContext<PosibleIContextoDeAutorización>(null);

export function ProveedorDeAutorización({ children }: { children: ReactNode }) {
    const {
        conectado,
        estáAutorizado
    } = usarConectado();

    useEffect(() => {
        (async () => {
           await estáAutorizado();
        })();
    }, []);

    const valor = useMemo(() => ({ conectado, refrescar: estáAutorizado }),
        [conectado, estáAutorizado]);
    
    return (
        <ContextoDeAutorización.Provider value={valor}>
            {children}
        </ContextoDeAutorización.Provider>
    );
}

export function usarAutorización() {
    const contexto: PosibleIContextoDeAutorización = useContext(ContextoDeAutorización);
    if (!contexto) {
        throw new Error("El contexto de autorización no está disponible. " +
                        "Asegúrate de envolver tu componente con " +
                        "ProveedorDeAutorización.");
    }
    return contexto;
}

