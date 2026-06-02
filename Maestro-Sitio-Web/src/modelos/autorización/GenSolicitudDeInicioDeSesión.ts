import {
    ServicioDeCodificaciónDeContraseñas
} from "../../servicios/autorización/ServicioDeCodificaciónDeContraseñas.ts";
import {
    inyectar,
} from "../../servicios/id/ProveedorDeServicios.ts";
import {SolicitudDeInicioDeSesión} from "./tipos.ts";

export class GenSolicitudDeInicioDeSesión {
    private _correoElectrónico: string;
    private _contraseña: string;
    private codificadorDeContraseñas: ServicioDeCodificaciónDeContraseñas = inyectar(ServicioDeCodificaciónDeContraseñas);
    public constructor(correoElectrónico: string, contraseña: string) {
        this._correoElectrónico = correoElectrónico;
        this._contraseña = contraseña;
    }

    public tieneCamposSinRellenar(): boolean {
        return !this._correoElectrónico || !this._contraseña;
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
            correoElectrónico: this._correoElectrónico,
            contraseña: contraseñaSegura
        };
    }
}
