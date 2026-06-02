import {singleton} from "tsyringe";

@singleton()
export class AlmacénDeTokenDeAcceso {
    private tokenDeAcceso: string | null = null;

    public obtener(): string | null {
        return this.tokenDeAcceso;
    }

    public asignar(token: string | null): void {
        this.tokenDeAcceso = token;
    }

    public limpiar(): void {
        this.asignar(null);
    }
}
