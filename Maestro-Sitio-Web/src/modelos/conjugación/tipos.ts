export type Verbo = string;

export enum Pronombre {
    Yo = "Yo",
    Tú = "Tú",
    Él = "Él",
    Ella = "Ella",
    Nosotros = "Nosotros",
    Ellos = "Ellos",
    Usted = "Usted",
    Ustedes = "Ustedes"
}

export const pronombres: Pronombre[] = [
    Pronombre.Yo,
    Pronombre.Tú,
    Pronombre.Él,
    Pronombre.Ella,
    Pronombre.Nosotros,
    Pronombre.Ellos,
    Pronombre.Usted,
    Pronombre.Ustedes
];

export type VerboConjugado = string;

export type VerboConjugadoHttp = {
    verboConjugado: VerboConjugado;
}
