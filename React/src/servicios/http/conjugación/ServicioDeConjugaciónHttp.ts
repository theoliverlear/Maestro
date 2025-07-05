import {injectable} from "tsyringe";
import {ClienteHttp} from "../ClienteHttp.ts";
import type {
    Pronombre,
    Verbo,
    VerboConjugado, VerboConjugadoHttp
} from "../../../modelos/conjugación/tipos.ts";

@injectable()
export class ServicioDeConjugaciónHttp extends ClienteHttp<any, VerboConjugadoHttp> {
    private static readonly URL: string = "/conj/";
    constructor() {
        super(ServicioDeConjugaciónHttp.URL);
    }

    public async obtenerConjugación(verbo: Verbo, pronombre: Pronombre): Promise<VerboConjugadoHttp> {
        this.url = `${ServicioDeConjugaciónHttp.URL}${verbo}/${pronombre}`;
        return await this.get();
    }
}