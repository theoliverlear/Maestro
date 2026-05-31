export interface RecursoDeImagen {
    src: string;
    alt: string;
}

const rutaAccesoDeImagen: string = "src/activos/imágenes/";
const rutaAccesoDeImagenDelIcono: string = rutaAccesoDeImagen + "icono/"
const rutaAccesoDeImagenDelLogotipo: string = rutaAccesoDeImagen + "logo/"

export function obtenerRutaDeImagen(nombreDelArchivo: string): string {
    return rutaAccesoDeImagen + nombreDelArchivo;
}

export function obtenerRutaDeImagenDelLogotipo(nombreDelArchivo: string): string {
    return rutaAccesoDeImagenDelLogotipo + nombreDelArchivo;
}

export function obtenerRutaDeImagenDelIcono(nombreDelArchivo: string): string {
    return rutaAccesoDeImagenDelIcono + nombreDelArchivo;
}

export const recursoDeImagenDelLogotipo: RecursoDeImagen = {
    src: obtenerRutaDeImagenDelLogotipo('logo.jpg'),
    alt: 'Logotipo de la aplicación'
};

export const recursoDeImagenDelLogotipoTransparente: RecursoDeImagen = {
    src: obtenerRutaDeImagenDelLogotipo('logotipo_transparente.png'),
    alt: 'Logotipo de aplicación transparente'
};

export const recursoDeImagenDeIconoDesplegable: RecursoDeImagen = {
    src: obtenerRutaDeImagenDelIcono('icono_desplegable.svg'),
    alt: 'Icono de menú desplegable'
};

export const recursoDeImagenDeIconoDeUsuarioPredeterminado: RecursoDeImagen = {
    src: obtenerRutaDeImagenDelIcono('icono_de_usuario_predeterminado.svg'),
    alt: 'Icono de usuario predeterminado'
};

export const recursoDeImagenDeIconoDeCerrar: RecursoDeImagen = {
    src: obtenerRutaDeImagenDelIcono('icono_de_cerrar.png'),
    alt: 'Icono de cerrar'
};

export const recursoDeImagenDeIconoDeCerrarBlanco: RecursoDeImagen = {
    src: obtenerRutaDeImagenDelIcono('icono_de_cerrar_blanco.png'),
    alt: 'Icono de cerrar blanco'
}