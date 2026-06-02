import axios, {type AxiosInstance, type InternalAxiosRequestConfig} from 'axios';
import {container} from "tsyringe";
import {AlmacénDeTokenDeAcceso} from "../autorización/AlmacénDeTokenDeAcceso.ts";
import {EstadoDeAutorización} from "../../modelos/autorización/tipos.ts";
import {ServicioDePruebaDpop} from "../autorización/dpop/ServicioDePruebaDpop.ts";

const almacénDeTokenDeAcceso: AlmacénDeTokenDeAcceso = container.resolve(AlmacénDeTokenDeAcceso);
const servicioDePruebaDpop: ServicioDePruebaDpop = container.resolve(ServicioDePruebaDpop);

// TODO: Debería utilizar la fábrica en su lugar. Podría presentar problemas
//       de bloqueo.
export const http: AxiosInstance = axios.create({
    baseURL: import.meta.env.VITE_API_URL || 'http://localhost:30117/api',
    timeout: 10_000,
    withCredentials: true
});

http.interceptors.request.use(async (config: InternalAxiosRequestConfig): Promise<InternalAxiosRequestConfig> => {
    const token: string | null = almacénDeTokenDeAcceso.obtener();
    const url: string = construirUrlAbsoluta(config.url ?? "", config.baseURL ?? http.defaults.baseURL);
    config.headers.DPoP = await servicioDePruebaDpop.construirPrueba(
        config.method ?? "GET",
        url,
        token
    );
    if (token) {
        config.headers.Authorization = `DPoP ${token}`;
    }
    return config;
});

http.interceptors.response.use(respuesta => {
    const token = (respuesta.data as EstadoDeAutorización | undefined)?.token;
    if (token) {
        almacénDeTokenDeAcceso.asignar(token);
    }
    return respuesta;
}, async error => {
    const solicitudOriginal = error.config;
    const url: string = solicitudOriginal?.url ?? "";
    const esSolicitudDeActualización: boolean = url.includes("/autorización/actualizar");
    const esSolicitudDeAcceso: boolean = url.includes("/autorización/acceso");
    const esSolicitudDeRegistro: boolean = url.includes("/autorización/registro");
    if (error.response?.status !== 401 ||
        esSolicitudDeActualización ||
        esSolicitudDeAcceso ||
        esSolicitudDeRegistro ||
        // TODO: Agregar una definición de tipos más estricta.
        (solicitudOriginal as any)?._reintentado) {
        throw error;
    }
    // TODO: Agregar una definición de tipos más estricta.
    (solicitudOriginal as any)._reintentado = true;
    try {
        // TODO: Extraer constante de URL.
        const respuesta = await http.post<EstadoDeAutorización>("/autorización/actualizar", {});
        if (!respuesta.data.esAutorizado || !respuesta.data.token) {
            almacénDeTokenDeAcceso.limpiar();
            throw error;
        }

        almacénDeTokenDeAcceso.asignar(respuesta.data.token);
        solicitudOriginal.headers = solicitudOriginal.headers ?? {};
        const url: string = construirUrlAbsoluta(solicitudOriginal.url ?? "",
            solicitudOriginal.baseURL ?? http.defaults.baseURL);
        solicitudOriginal.headers.DPoP = await servicioDePruebaDpop.construirPrueba(
            solicitudOriginal.method ?? "GET",
            url,
            respuesta.data.token
        );
        solicitudOriginal.headers.Authorization = `DPoP ${respuesta.data.token}`;
        return http(solicitudOriginal);
    } catch {
        almacénDeTokenDeAcceso.limpiar();
        throw error;
    }
});

function construirUrlAbsoluta(url: string, baseUrl?: string): string {
    if (/^https?:\/\//i.test(url)) {
        return url;
    }

    const base: string = baseUrl ?? "";
    return `${base.replace(/\/$/, "")}/${url.replace(/^\//, "")}`;
}
