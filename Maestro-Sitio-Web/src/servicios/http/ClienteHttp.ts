import {injectable} from "tsyringe";
import {http} from "./http.ts";

@injectable()
export class ClienteHttp<Enviar, Recibir> {
    private _url: string;

    constructor(url: string) {
        this._url = url;
    }

    get url(): string {
        return this._url;
    }

    set url(nuevaUrl: string) {
        this._url = nuevaUrl;
    }

    public async get(): Promise<Recibir> {
        let respuesta: Recibir | null;
        respuesta = await http.get(this._url).then(cargaÚtil => {
            return cargaÚtil.data as Recibir;
        });
        if (!respuesta) {
            throw new Error("Error al llamar a una solicitud GET.")
        }
        return respuesta;
    }

    public async post(cargaÚtil: Enviar): Promise<Recibir> {
        let respuesta: Recibir | null;
        respuesta = await http.post(this._url, cargaÚtil).then(cargaÚtil => {
            return cargaÚtil.data as Recibir;
        });
        if (!respuesta) {
            throw new Error("Error al llamar a una solicitud POST.")
        }
        return respuesta;
    }

    public async put(cargaÚtil: Enviar): Promise<Recibir> {
        let respuesta: Recibir | null;
        respuesta = await http.put(this._url, cargaÚtil).then(cargaÚtil => {
            return cargaÚtil.data as Recibir;
        });
        if (!respuesta) {
            throw new Error("Error al llamar a una solicitud PUT.")
        }
        return respuesta;
    }

    public async delete(): Promise<Recibir> {
        let respuesta: Recibir | null;
        respuesta = await http.delete(this._url).then(cargaÚtil => {
            return cargaÚtil.data as Recibir;
        });
        if (!respuesta) {
            throw new Error("Error al llamar a una solicitud DELETE.")
        }
        return respuesta;
    }
}