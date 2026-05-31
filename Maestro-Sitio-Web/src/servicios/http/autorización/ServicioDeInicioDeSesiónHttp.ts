import {ClienteHttp} from "../ClienteHttp.ts";
import {
    EstadoDeAutorización,
    SolicitudDeInicioDeSesión
} from "../../../modelos/autorización/tipos.ts";
import {injectable} from "tsyringe";

@injectable()
export class ServicioDeInicioDeSesiónHttp extends ClienteHttp<SolicitudDeInicioDeSesión, EstadoDeAutorización> {
    private static readonly URL = "/autorización/acceso";

    constructor() {
        super(ServicioDeInicioDeSesiónHttp.URL);
    }

    public async acceso(solicitud: SolicitudDeInicioDeSesión): Promise<EstadoDeAutorización> {
        return await this.post(solicitud);
    }
}