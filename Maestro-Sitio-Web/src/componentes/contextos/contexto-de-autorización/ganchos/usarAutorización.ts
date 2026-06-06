import {PosibleIContextoDeAutorización} from "../modelos/tipos.ts";
import {useContext} from "react";
import {ContextoDeAutorización} from "../ContextoDeAutorización.tsx";

export function usarAutorización() {
    const contexto: PosibleIContextoDeAutorización = useContext(ContextoDeAutorización)
    if (!contexto) {
        throw new Error("El contexto de autorización no está disponible. " +
            "Asegúrate de envolver tu componente con " +
            "ProveedorDeAutorización.")
    }
    return contexto
}