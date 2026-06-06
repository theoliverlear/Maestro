import {calculateJwkThumbprint, exportJWK, generateKeyPair, type JWK} from "jose"
import {singleton} from "tsyringe"

@singleton()
export class ServicioDeClaveDpop {
    private parDeClaves: CryptoKeyPair | null = null
    private clavePública: JWK | null = null
    private huella: string | null = null

    public async obtenerParDeClaves(): Promise<CryptoKeyPair> {
        if (!this.parDeClaves) {
            this.parDeClaves = await generateKeyPair("ES256", {extractable: true})
        }
        return this.parDeClaves
    }

    public async obtenerClavePública(): Promise<JWK> {
        if (!this.clavePública) {
            const parDeClaves = await this.obtenerParDeClaves()
            this.clavePública = await exportJWK(parDeClaves.publicKey)
        }
        return this.clavePública
    }

    public async obtenerHuella(): Promise<string> {
        if (!this.huella) {
            this.huella = await calculateJwkThumbprint(await this.obtenerClavePública(), "sha256")
        }
        return this.huella
    }

    public limpiar(): void {
        this.parDeClaves = null
        this.clavePública = null
        this.huella = null
    }
}
