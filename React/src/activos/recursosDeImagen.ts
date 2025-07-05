export interface RecursoDeImagen {
    src: string;
    alt: string;
}

const rutaAccesoDeImagen: string = "src/activos/imágenes/";
const rutaAccesoDeImagenDelLogotipo: string = rutaAccesoDeImagen + "logo/"

export function obtenerRutaDeImagen(nombreDelArchivo: string): string {
    return rutaAccesoDeImagen + nombreDelArchivo;
}

export function obtenerRutaDeImagenDelLogotipo(nombreDelArchivo: string): string {
    return rutaAccesoDeImagenDelLogotipo + nombreDelArchivo;
}

export const recursoDeImagenDelLogotipo: RecursoDeImagen = {
    src: obtenerRutaDeImagenDelLogotipo('logo.jpg'),
    alt: 'Logotipo de la aplicación'
};

export const recursoDeImagenDelLogotipoTransparente: RecursoDeImagen = {
    src: obtenerRutaDeImagenDelLogotipo('logotipo_transparente.png'),
    alt: 'Logotipo de aplicación transparente'
};