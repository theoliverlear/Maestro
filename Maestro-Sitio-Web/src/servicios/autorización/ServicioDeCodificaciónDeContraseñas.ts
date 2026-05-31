import {injectable} from "tsyringe";
import CryptoJS from 'crypto-js';

@injectable()
export class ServicioDeCodificaciónDeContraseñas {
    public codificar(contraseña: string): string {
        return CryptoJS.SHA256(contraseña).toString();
    }
}