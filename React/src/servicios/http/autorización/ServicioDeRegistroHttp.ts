import {injectable} from "tsyringe";
import {ClienteHttp} from "../ClienteHttp.ts";
import {
    EstadoDeAutorización,
    SolicitudDeRegistro
} from "../../../modelos/autorización/tipos.ts";

@injectable()
export class ServicioDeRegistroHttp extends ClienteHttp<SolicitudDeRegistro, EstadoDeAutorización> {
    private static readonly URL: string = "/autorización/registro";

    constructor() {
        super(ServicioDeRegistroHttp.URL);
    }

    public async registrar(solicitud: any): Promise<any> {
        return await this.post(solicitud);
    }
}