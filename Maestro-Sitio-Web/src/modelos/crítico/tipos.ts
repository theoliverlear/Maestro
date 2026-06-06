export enum ModoCrítico {
    Natural = "natural",
    Formal = "formal",
    Cultural = "cultural",
    Directo = "directo"
}

export enum FocoCrítico {
    Todo = "todo",
    Gramática = "gramática",
    Estilo = "estilo",
    Contenido = "contenido"
}

export type OpciónPromocionalCríticos<T extends string> = {
    valor: T;
    etiqueta: string;
}
export type TarjetaDeResultado = {
    título: string;
    texto: string;
}
export type PuntoPromocionalDeCrítica = {
    título: string;
    texto: string;
}
export type ModoPromocionalDeCrítica = PuntoPromocionalDeCrítica & {
    etiqueta: string;
}
export type PasoPromocionalDeCrítica = PuntoPromocionalDeCrítica & {
    número: string;
}
