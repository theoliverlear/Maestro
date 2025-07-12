import {SolicitudDeRegistro} from "./tipos.ts";
import {usarInyectar} from "../../servicios/id/ProveedorDeServicios.ts";
import {
    ServicioDeCodificaciónDeContraseñas
} from "../../servicios/autorización/ServicioDeCodificaciónDeContraseñas.ts";
import {
    EstadosDeValidezDeAutorización
} from "../../componentes/elementos/grupos-elementos-autorización/modelos/EstadosDeValidezDeAutorización.ts";

export class GenSolicitudDeRegistro {
    private _nombreDeUsuario: string;
    private _correoElectrónico: string;
    private _contraseña: string;
    private _confirmarContraseña: string;
    private codificadorDeContraseñas: ServicioDeCodificaciónDeContraseñas = usarInyectar(ServicioDeCodificaciónDeContraseñas);
    public constructor(nombreDeUsuario: string,
                       correoElectrónico: string,
                       contraseña: string,
                       confirmarContraseña: string) {
        this._nombreDeUsuario = nombreDeUsuario;
        this._correoElectrónico = correoElectrónico;
        this._contraseña = contraseña;
        this._confirmarContraseña = confirmarContraseña;
    }

    public obtenerEstadosNoVálidos(): EstadosDeValidezDeAutorización {
        if (this.tieneCamposSinRellenar()) {
            return EstadosDeValidezDeAutorización.CAMPOS_SIN_RELLENAR;
        }
        if (!this.esCorreoElectrónicoValido()) {
            return EstadosDeValidezDeAutorización.CORREO_ELECTRÓNICO_NO_VÁLIDO;
        }
        if (!this.contraseñasCoinciden()) {
            return EstadosDeValidezDeAutorización.FALTA_DE_COINCIDENCIA_DE_CONTRASEÑAS;
        }
        return EstadosDeValidezDeAutorización.VÁLIDO;
    }

    public esCorreoElectrónicoValido(): boolean {
        const patrónVálido: RegExp = new RegExp('^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$');
        return patrónVálido.test(this._correoElectrónico);
    }

    public obtenerModelo(): SolicitudDeRegistro {
        if (!this.esVálido()) {
            throw new Error("Hay entradas no válidas. No se puede construir un modelo.");
        }
        const contraseñaSegura: string = this.codificadorDeContraseñas.codificar(this._contraseña);
        return {
            nombreDeUsuario: this._nombreDeUsuario,
            contraseña: contraseñaSegura,
            correoElectrónico: this._correoElectrónico
        };
    }

    public esVálido(): boolean {
        return !this.cualquierEntradaNoVálida();
    }

    public tieneCamposSinRellenar(): boolean {
        return !this._nombreDeUsuario ||
               !this._correoElectrónico ||
               !this._contraseña ||
               !this._confirmarContraseña;
    }

    public cualquierEntradaNoVálida(): boolean {
        const cualquierNulo: boolean = this.tieneCamposSinRellenar();
        const correoElectrónicoVálido: boolean = this.esCorreoElectrónicoValido();
        const contraseñasCoinciden: boolean = this.contraseñasCoinciden();
        return cualquierNulo || !correoElectrónicoVálido || !contraseñasCoinciden;
    }

    public contraseñasCoinciden(): boolean {
        return this._contraseña === this._confirmarContraseña;
    }

    get confirmarContraseña(): string {
        return this._confirmarContraseña;
    }

    set confirmarContraseña(value: string) {
        this._confirmarContraseña = value;
    }
    get contraseña(): string {
        return this._contraseña;
    }

    set contraseña(value: string) {
        this._contraseña = value;
    }
    get correoElectrónico(): string {
        return this._correoElectrónico;
    }

    set correoElectrónico(value: string) {
        this._correoElectrónico = value;
    }
    get nombreDeUsuario(): string {
        return this._nombreDeUsuario;
    }

    set nombreDeUsuario(value: string) {
        this._nombreDeUsuario = value;
    }
}