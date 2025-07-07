import './Entrada.scss';
import {ChangeEvent, ReactElement, useState} from "react";
import {TipoDeEntrada} from "./modelos/TipoDeEntrada.ts";

interface PropsEntrada {
    tipo: TipoDeEntrada;
    enLaEntrada: (valor: string | number) => void;
    marcadorDePosición?: string;
    min?: number;
    max?: number;
    valorPredeterminado?: number | string;
}

function Entrada(props: PropsEntrada): ReactElement {
    const [valor, asignarValor] = useState<string | number>(props.valorPredeterminado ? props.valorPredeterminado : '');
    function cambioDeManejo(evento: ChangeEvent<HTMLInputElement>): void {
        const valorDeEntrada: string = evento.target.value;
        asignarValor(valorDeEntrada);
        props.enLaEntrada(valorDeEntrada);
    }

    function esRango(): boolean {
        return props.tipo === TipoDeEntrada.RANGO;
    }

    function esCaja(): boolean {
        return props.tipo === TipoDeEntrada.CAJA;
    }

    function obtenerElemento(): ReactElement {
        if (esRango()) {
            return <input type={props.tipo as string}
                          onChange={cambioDeManejo}
                          placeholder={props.marcadorDePosición || ''}
                          min={props.min ? props.min : 0}
                          max={props.max ? props.max : 100000}
                          value={valor}/>;
        } else if (esCaja()) {
            return <input type={props.tipo as string}
                          onChange={cambioDeManejo}
                          checked={props.valorPredeterminado ? Boolean(props.valorPredeterminado) : false}/>;
        }
        return <input type={props.tipo as string}
                      onChange={cambioDeManejo}
                      placeholder={props.marcadorDePosición || ''}
                      min={props.min ? props.min : 0}
                      max={props.max ? props.max : 100000}
                      value={valor}/>;
    }

    return (
        <div className={"entrada"}>
            {obtenerElemento()}
        </div>
    );
}

export default Entrada;