import {base64url, SignJWT, type JWK} from "jose"
import {inject, injectable} from "tsyringe"
import {ServicioDeClaveDpop} from "./ServicioDeClaveDpop.ts"

@injectable()
export class ServicioDePruebaDpop {
    public constructor(@inject(ServicioDeClaveDpop)
                       private readonly servicioDeClaveDpop: ServicioDeClaveDpop) {
    }

    public async construirPrueba(método: string,
                                 url: string,
                                 tokenDeAcceso?: string | null): Promise<string> {
        const parDeClaves: CryptoKeyPair = await this.servicioDeClaveDpop.obtenerParDeClaves()
        const clavePública: JWK = await this.servicioDeClaveDpop.obtenerClavePública()
        const ahoraEnSegundos: number = Math.floor(Date.now() / 1000)
        const hashDeToken: string | null = tokenDeAcceso
            ? await this.crearHashDeToken(tokenDeAcceso)
            : null
        const prueba = new SignJWT({
            htm: método.toUpperCase(),
            htu: url,
            iat: ahoraEnSegundos,
            jti: crypto.randomUUID(),
            ...(hashDeToken ? {ath: hashDeToken} : {})
        })

        return await prueba
            .setProtectedHeader({
                alg: "ES256",
                typ: "dpop+jwt",
                jwk: clavePública
            })
            .sign(parDeClaves.privateKey)
    }

    private async crearHashDeToken(tokenDeAcceso: string): Promise<string> {
        const datos = new TextEncoder().encode(tokenDeAcceso)
        const hash = await crypto.subtle.digest("SHA-256", datos)
        return base64url.encode(new Uint8Array(hash))
    }
}
