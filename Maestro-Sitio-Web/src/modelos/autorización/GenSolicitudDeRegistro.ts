import {SolicitudDeRegistro} from "./tipos.ts";
import {
    inyectar,
} from "../../servicios/id/ProveedorDeServicios.ts";
import {
    ServicioDeCodificaciónDeContraseñas
} from "../../servicios/autorización/ServicioDeCodificaciónDeContraseñas.ts";
import {
    EstadosDeValidezDeAutorización
} from "../../componentes/elementos/grupos-elementos-autorización/modelos/EstadosDeValidezDeAutorización.ts";

export class GenSolicitudDeRegistro {
    private _correoElectrónico: string;
    private _contraseña: string;
    private _confirmarContraseña: string;
    private codificadorDeContraseñas: ServicioDeCodificaciónDeContraseñas = inyectar(ServicioDeCodificaciónDeContraseñas);
    public constructor(correoElectrónico: string = "",
                       contraseña: string = "",
                       confirmarContraseña: string = "") {
        this._correoElectrónico = correoElectrónico;
        this._contraseña = contraseña;
        this._confirmarContraseña = confirmarContraseña;
    }

    public obtenerOtrosEstadosNoVálidos(estadoExcluido: EstadosDeValidezDeAutorización): EstadosDeValidezDeAutorización {
        const estadosExcluidos: EstadosDeValidezDeAutorización[] = [
            EstadosDeValidezDeAutorización.CamposSinRellenar,
            estadoExcluido
        ];
        if (!this.esCorreoElectrónicoValido() &&
            !estadosExcluidos.includes(EstadosDeValidezDeAutorización.CorreoElectrónicoNoVálido)) {
            return EstadosDeValidezDeAutorización.CorreoElectrónicoNoVálido;
        }
        if (this.tieneContraseñasParaComparar() &&
            !this.contraseñasCoinciden() &&
            !estadosExcluidos.includes(EstadosDeValidezDeAutorización.FaltaDeCoincidenciaDeContraseñas)) {
            return EstadosDeValidezDeAutorización.FaltaDeCoincidenciaDeContraseñas;
        }
        return EstadosDeValidezDeAutorización.Válido;
    }

    public obtenerEstadosNoVálidos(): EstadosDeValidezDeAutorización {
        if (this.tieneCamposSinRellenar()) {
            return EstadosDeValidezDeAutorización.CamposSinRellenar;
        }
        if (!this.esCorreoElectrónicoValido()) {
            return EstadosDeValidezDeAutorización.CorreoElectrónicoNoVálido;
        }
        if (!this.contraseñasCoinciden()) {
            return EstadosDeValidezDeAutorización.FaltaDeCoincidenciaDeContraseñas;
        }
        return EstadosDeValidezDeAutorización.Válido;
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
            contraseña: contraseñaSegura,
            correoElectrónico: this._correoElectrónico
        };
    }

    public esVálido(): boolean {
        return !this.cualquierEntradaNoVálida();
    }

    public tieneCamposSinRellenar(): boolean {
        return !this._correoElectrónico ||
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

    public tieneContraseñasParaComparar(): boolean {
        return !!this._contraseña && !!this._confirmarContraseña;
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
}
