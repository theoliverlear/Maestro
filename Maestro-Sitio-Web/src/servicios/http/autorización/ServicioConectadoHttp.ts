// ServicioConectadoHttp.ts
import {ClienteHttp} from "../ClienteHttp.ts";
import {EstadoDeAutorización} from "../../../modelos/autorización/tipos.ts";
import {injectable} from "tsyringe";

@injectable()
export class ServicioConectadoHttp extends ClienteHttp<any, EstadoDeAutorización> {
    private static readonly URL: string = "/autorización/conectado";

    constructor() {
        super(ServicioConectadoHttp.URL);
    }

    public async conectado(): Promise<EstadoDeAutorización> {
        return await this.get();
    }
}