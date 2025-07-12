// usarConectado.ts

import {useCallback, useState} from "react";
import {usarInyectar} from "../servicios/id/ProveedorDeServicios.ts";
import {
    ServicioConectadoHttp
} from "../servicios/http/autorización/ServicioConectadoHttp.ts";
import {EstadoDeAutorización} from "../modelos/autorización/tipos.ts";

const esDesarrollo: boolean = false;

export function usarConectado() {
    const [conectado, asignarConectado] = useState<boolean>(false);
    const clienteConectado = usarInyectar(ServicioConectadoHttp);

    const estáAutorizado: () => Promise<void> = useCallback(async () => {
        if (esDesarrollo) {
            asignarConectado(true);
            return;
        }
        const estado: EstadoDeAutorización = await clienteConectado.conectado();
        asignarConectado(estado.esAutorizado);
    }, []);

    return {
        conectado,
        estáAutorizado
    };
}