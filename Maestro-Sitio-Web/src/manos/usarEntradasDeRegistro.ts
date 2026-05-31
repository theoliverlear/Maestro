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

    const actualizarCampo = useCallback(
        (campo: string, valor: string) => {
            asignarSolicitud((prev: GenSolicitudDeRegistro) => {
                const nuevo: GenSolicitudDeRegistro = new GenSolicitudDeRegistro(
                    prev.nombreDeUsuario,
                    prev.correoElectrónico,
                    prev.contraseña,
                    prev.confirmarContraseña
                );
                switch (campo) {
                    case "nombreDeUsuario":
                        nuevo.nombreDeUsuario = valor;
                        break;
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
            });
        }, []);

    const manejarNombreDeUsuario = useCallback(
        (valor: string | number) => {
            actualizarCampo("nombreDeUsuario", valor as string);
        }, [actualizarCampo]);

    const manejarCorreoElectrónico = useCallback(
        (valor: string | number) => {
            actualizarCampo("correoElectrónico", valor as string);
            if (!solicitud.esCorreoElectrónicoValido()) {
                asignarMensaje(EstadosDeValidezDeAutorización.CORREO_ELECTRÓNICO_NO_VÁLIDO);
            } else {
                asignarMensaje(solicitud.obtenerOtrosEstadosNoVálidos(mensaje));
            }
        }, [actualizarCampo, solicitud, mensaje]);

    const manejarContraseña = useCallback(
        (valor: string | number) => {
            actualizarCampo("contraseña", valor as string);
            if (solicitud.confirmarContraseña && !solicitud.contraseñasCoinciden()) {
                asignarMensaje(EstadosDeValidezDeAutorización.FALTA_DE_COINCIDENCIA_DE_CONTRASEÑAS);
            } else {
                asignarMensaje(
                    solicitud.obtenerOtrosEstadosNoVálidos(mensaje)
                );
            }
        }, [actualizarCampo, solicitud, mensaje]);

    const manejarConfirmarContraseña = useCallback(
        (valor: string | number) => {
            actualizarCampo("confirmarContraseña", valor as string);
            if (!solicitud.contraseñasCoinciden()) {
                asignarMensaje(EstadosDeValidezDeAutorización.FALTA_DE_COINCIDENCIA_DE_CONTRASEÑAS);
            } else {
                asignarMensaje(solicitud.obtenerOtrosEstadosNoVálidos(mensaje));
            }
        }, [actualizarCampo, solicitud, mensaje]);

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
            manejarNombreDeUsuario,
            manejarCorreoElectrónico,
            manejarContraseña,
            manejarConfirmarContraseña,
            manejarEnvío
        }
    }
}