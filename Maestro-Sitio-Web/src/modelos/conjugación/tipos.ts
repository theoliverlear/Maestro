export type Verbo = string;
export const pronombres: string[] = ["Yo", "Tú", "Él", "Ella", "Nosotros", "Ellos", "Usted", "Ustedes"] as const;
export type Pronombre = typeof pronombres[number];
export type VerboConjugado = string;

export type VerboConjugadoHttp = {
    verboConjugado: VerboConjugado;
}