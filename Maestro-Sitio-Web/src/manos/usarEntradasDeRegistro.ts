import {useCallback, useState} from "react";
import { GenSolicitudDeRegistro } from "../modelos/autorización/GenSolicitudDeRegistro";
import { EstadosDeValidezDeAutorización } from "../componentes/elementos/grupos-elementos-autorización/modelos/EstadosDeValidezDeAutorización";

export function usarEntradasDeRegistro() {
    const [solicitud, asignarSolicitud] = useState<GenSolicitudDeRegistro>(
        new GenSolicitudDeRegistro()
    );

    const [mensaje, asignarMensaje] = useState<EstadosDeValidezDeAutorización>(
        EstadosDeValidezDeAutorización.VÁLIDO
    );

    const crearSolicitudActualizada = useCallback(
        (campo: string, valor: string): GenSolicitudDeRegistro => {
            const nuevo: GenSolicitudDeRegistro = new GenSolicitudDeRegistro(
                solicitud.correoElectrónico,
                solicitud.contraseña,
                solicitud.confirmarContraseña
            );
            switch (campo) {
                case "correoElectrónico":
                    nuevo.correoElectrónico = valor;
                    break;
                case "contraseña":
                    nuevo.contraseña = valor;
                    break;
                case "confirmarContraseña":
                    nuevo.confirmarContraseña = valor;
                    break;
                default:
                    throw new Error(`Campo desconocido: ${campo}`);
            }
            return nuevo;
        }, [solicitud]);

    const actualizarSolicitudYMensaje = useCallback(
        (campo: string, valor: string): GenSolicitudDeRegistro => {
            const nuevo: GenSolicitudDeRegistro = crearSolicitudActualizada(campo, valor);
            asignarSolicitud(nuevo);
            return nuevo;
        }, [crearSolicitudActualizada]);

    const manejarCorreoElectrónico = useCallback(
        (valor: string | number) => {
            const nuevaSolicitud = actualizarSolicitudYMensaje("correoElectrónico", valor as string);
            if (!nuevaSolicitud.esCorreoElectrónicoValido()) {
                asignarMensaje(EstadosDeValidezDeAutorización.CORREO_ELECTRÓNICO_NO_VÁLIDO);
            } else {
                asignarMensaje(nuevaSolicitud.obtenerOtrosEstadosNoVálidos(mensaje));
            }
        }, [actualizarSolicitudYMensaje, mensaje]);

    const manejarContraseña = useCallback(
        (valor: string | number) => {
            const nuevaSolicitud = actualizarSolicitudYMensaje("contraseña", valor as string);
            if (nuevaSolicitud.confirmarContraseña && !nuevaSolicitud.contraseñasCoinciden()) {
                asignarMensaje(EstadosDeValidezDeAutorización.FALTA_DE_COINCIDENCIA_DE_CONTRASEÑAS);
            } else {
                asignarMensaje(
                    nuevaSolicitud.obtenerOtrosEstadosNoVálidos(mensaje)
                );
            }
        }, [actualizarSolicitudYMensaje, mensaje]);

    const manejarConfirmarContraseña = useCallback(
        (valor: string | number) => {
            const nuevaSolicitud = actualizarSolicitudYMensaje("confirmarContraseña", valor as string);
            if (nuevaSolicitud.confirmarContraseña && !nuevaSolicitud.contraseñasCoinciden()) {
                asignarMensaje(EstadosDeValidezDeAutorización.FALTA_DE_COINCIDENCIA_DE_CONTRASEÑAS);
            } else {
                asignarMensaje(nuevaSolicitud.obtenerOtrosEstadosNoVálidos(mensaje));
            }
        }, [actualizarSolicitudYMensaje, mensaje]);

    const manejarEnvío = useCallback((): boolean => {
        if (!solicitud.esVálido()) {
            asignarMensaje(solicitud.obtenerEstadosNoVálidos());
            return false;
        }
        return true;
    }, [solicitud]);

    return {
        solicitud,
        mensaje,
        manipuladores: {
            manejarCorreoElectrónico,
            manejarContraseña,
            manejarConfirmarContraseña,
            manejarEnvío
        }
    }
}
