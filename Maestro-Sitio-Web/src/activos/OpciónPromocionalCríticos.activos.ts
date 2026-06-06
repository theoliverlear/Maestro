import {
    FocoCrítico,
    ModoCrítico,
    OpciónPromocionalCríticos
} from "../modelos/crítico/tipos.ts"

export const modosPromocionalDeCríticos: OpciónPromocionalCríticos<ModoCrítico>[] = [
    {valor: ModoCrítico.Natural, etiqueta: "Natural"},
    {valor: ModoCrítico.Formal, etiqueta: "Formal"},
    {valor: ModoCrítico.Cultural, etiqueta: "Cultural"},
    {valor: ModoCrítico.Directo, etiqueta: "Directo"}
]
export const focosPromocionalDeCríticos: OpciónPromocionalCríticos<FocoCrítico>[] = [
    {valor: FocoCrítico.Todo, etiqueta: "Todo"},
    {valor: FocoCrítico.Gramática, etiqueta: "Gramática"},
    {valor: FocoCrítico.Estilo, etiqueta: "Estilo"},
    {valor: FocoCrítico.Contenido, etiqueta: "Contenido"}
]
