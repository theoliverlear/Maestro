import {
    FocoCrítico,
    ModoCrítico,
    TarjetaDeResultado
} from "../../modelos/crítico/tipos.ts";

export function crearResultado(texto: string, modo: ModoCrítico, foco: FocoCrítico): TarjetaDeResultado[] {
    const entrada: string = texto.trim()
    const frase: string = entrada.length > 0 ? entrada : "Escribe un intento para recibir crítica."
    return [
        {
            título: "Elogio",
            texto: "La intención principal se entiende. Hay una base clara para mejorar sin reescribir todo desde cero."
        },
        {
            título: "Crítica",
            texto: `Modo ${modo}, foco ${foco}: revisa precisión, naturalidad y fuerza expresiva en "${frase}".`
        },
        {
            título: "Versión sugerida",
            texto: "Me gusta esta ciudad porque tiene una historia muy rica, y todavía se nota en sus barrios, su arquitectura y sus tradiciones."
        },
        {
            título: "Siguiente intento",
            texto: "Reescribe la frase agregando un detalle concreto. Busca una imagen precisa antes de usar intensificadores como \"muy\"."
        }
    ]
}