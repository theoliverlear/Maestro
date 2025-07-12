export type SolicitudDeInicioDeSesión = {
    nombreDeUsuario: string;
    contraseña: string;
};

export type SolicitudDeRegistro = {
    nombreDeUsuario: string;
    contraseña: string;
    correoElectrónico: string;
};

export type EstadoDeAutorización = {
    esAutorizado: boolean;
};