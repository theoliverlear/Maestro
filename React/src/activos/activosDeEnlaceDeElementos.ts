export type EnlaceDeElemento = {
    enlace: string;
    texto: string;
}

export type EnlaceDelElementoDesplegable = {
    título: string;
    enlacesDeElemento: EnlaceDeElemento[];
}

export type EnlaceDeElementoDesplegableVinculado = {
    enlaceDelTítulo: EnlaceDeElemento;
    enlacesDeElemento: EnlaceDeElemento[];
}

export const enlaceDeCasa: EnlaceDeElemento = {
    enlace: "/",
    texto: "Casa"
};

export const enlaceDeConjugador: EnlaceDeElemento = {
    enlace: "/conj",
    texto: "Conjugador"
};

export const enlaceDePerfil: EnlaceDeElemento = {
    enlace: "/perfil",
    texto: "Perfil"
};
// NOTA: En inglés es "dashboard".
export const enlaceDePanel: EnlaceDeElemento = {
    enlace: "/panel",
    texto: "Panel"
};

export const enlaceDeJuegos: EnlaceDeElemento = {
    enlace: "/juegos",
    texto: "Juegos"
};

export const enlaceDeHerramientas: EnlaceDeElemento = {
    enlace: "/herramientas",
    texto: "Herramientas"
};

export const enlacesDePalabraReal: EnlaceDeElemento = {
    enlace: "/palabra-real",
    texto: "Palabra Real"
};

export const enlacesDePulsoDePalabras: EnlaceDeElemento = {
    enlace: "/pulso-de-palabras",
    texto: "Pulso de Palabras"
};

export const enlacesDeBarraDeNav: EnlaceDeElemento[] = [
    // TODO: Será una imagen de ancla.
    // enlaceDePerfil,
    enlaceDePanel
];

export const enlacesDelDesplegablesDeHerramientas: EnlaceDeElementoDesplegableVinculado = {
    enlaceDelTítulo: enlaceDeHerramientas,
    enlacesDeElemento: [
        enlaceDeConjugador
    ]
};

export const enlacesDelDesplegablesDeJuegos: EnlaceDeElementoDesplegableVinculado = {
    enlaceDelTítulo: enlaceDeJuegos,
    enlacesDeElemento: [
        enlacesDePalabraReal,
        enlacesDePulsoDePalabras
    ]
};