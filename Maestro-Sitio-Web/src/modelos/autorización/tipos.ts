export type SolicitudDeInicioDeSesión = {
    correoElectrónico: string;
    contraseña: string;
};

export type SolicitudDeRegistro = {
    contraseña: string;
    correoElectrónico: string;
};

export type EstadoDeAutorización = {
    esAutorizado: boolean;
};
