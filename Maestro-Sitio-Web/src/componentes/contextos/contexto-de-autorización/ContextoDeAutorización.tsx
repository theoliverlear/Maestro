// ContextoDeAutorización.tsx

import {
    Context,
    createContext,
    ReactElement,
    ReactNode,
    useEffect,
    useMemo
} from "react"
import {PosibleIContextoDeAutorización} from "./modelos/tipos.ts"
import {usarConectado} from "../../../ganchos/usarConectado.ts"

export interface IContextoDeAutorización {
    conectado: boolean;
    refrescar: () => Promise<void>;
}

export const ContextoDeAutorización: Context<PosibleIContextoDeAutorización> = createContext<PosibleIContextoDeAutorización>(null)

export function ProveedorDeAutorización({ children }: { children: ReactNode }): ReactElement {
    const {
        conectado,
        estáAutorizado
    } = usarConectado()

    useEffect(() => {
        (async () => {
           await estáAutorizado()
        })()
    }, [])

    const valor: IContextoDeAutorización = useMemo(() => ({ conectado, refrescar: estáAutorizado }),
        [conectado, estáAutorizado])
    
    return (
        <ContextoDeAutorización.Provider value={valor}>
            {children}
        </ContextoDeAutorización.Provider>
    )
}

