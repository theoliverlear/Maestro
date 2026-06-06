import {usarInyectar} from "../servicios/id/ProveedorDeServicios.ts";
import {
    ServicioDeConjugaciónHttp
} from "../servicios/http/conjugación/ServicioDeConjugaciónHttp.ts";
import {useCallback, useState} from "react";
import type {
    Pronombre,
    Verbo,
    VerboConjugado, VerboConjugadoHttp
} from "../modelos/conjugación/tipos.ts";

export function usarConjugación() {
    const conjugador: ServicioDeConjugaciónHttp = usarInyectar(ServicioDeConjugaciónHttp);
    const [verboConjugado, asignarVerboConjugado] = useState<VerboConjugado>("");

    const conjugado: (verbo: Verbo, pronombre: Pronombre) => void = useCallback(async (verbo: Verbo, pronombre: Pronombre): Promise<void> => {
        if (verbo && pronombre) {
            const verboNormalizado: string = verbo.toLowerCase().trim();
            const pronombreNormalizado: string = pronombre.toLowerCase().trim();
            const resultado: VerboConjugadoHttp = await conjugador.obtenerConjugación(verboNormalizado, pronombreNormalizado);
            asignarVerboConjugado(resultado.verboConjugado);
        } else {
            asignarVerboConjugado("");
        }
    }, []);

    return {
        verboConjugado,
        conjugado
    }
}