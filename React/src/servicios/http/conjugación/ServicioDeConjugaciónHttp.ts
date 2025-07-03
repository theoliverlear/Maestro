import {injectable} from "tsyringe";
import {ClienteHttp} from "../ClienteHttp.ts";
import type {
    Pronombre,
    Verbo,
    VerboConjugado
} from "../../../modelos/conjugación/tipos.ts";

@injectable()
export class ServicioDeConjugaciónHttp extends ClienteHttp<any, VerboConjugado> {
    private static readonly URL: string = "/casa/conj/";
    constructor() {
        super(ServicioDeConjugaciónHttp.URL);
    }

    public async obtenerConjugación(verbo: Verbo, pronombre: Pronombre): Promise<VerboConjugado> {
        this.url = `${ServicioDeConjugaciónHttp.URL}${verbo}/${pronombre}`;
        return await this.get();
    }
}