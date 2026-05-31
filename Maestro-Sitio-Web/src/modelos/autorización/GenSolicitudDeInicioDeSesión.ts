import {
    ServicioDeCodificaciónDeContraseñas
} from "../../servicios/autorización/ServicioDeCodificaciónDeContraseñas.ts";
import {usarInyectar} from "../../servicios/id/ProveedorDeServicios.ts";
import {SolicitudDeInicioDeSesión} from "./tipos.ts";

export class GenSolicitudDeInicioDeSesión {
    private _nombreDeUsuario: string;
    private _contraseña: string;
    private codificadorDeContraseñas: ServicioDeCodificaciónDeContraseñas = usarInyectar(ServicioDeCodificaciónDeContraseñas);
    public constructor(nombreDeUsuario: string, contraseña: string) {
        this._nombreDeUsuario = nombreDeUsuario;
        this._contraseña = contraseña;
    }

    public tieneCamposSinRellenar(): boolean {
        return !this._nombreDeUsuario || !this._contraseña;
    }

    public esVálido(): boolean {
        return !this.tieneCamposSinRellenar();
    }
    
    public obtenerModelo(): SolicitudDeInicioDeSesión {
        if (!this.esVálido()) {
            throw new Error("Hay entradas no válidas. No se puede construir un modelo.");
        }
        const contraseñaSegura: string = this.codificadorDeContraseñas.codificar(this._contraseña);
        return {
            nombreDeUsuario: this._nombreDeUsuario,
            contraseña: contraseñaSegura
        };
    }
}