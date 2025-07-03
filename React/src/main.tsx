import "reflect-metadata";
import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import App from './componentes/app/App.tsx';
import {ProveedorDeInyecciones} from "./servicios/id/ProveedorDeServicios.ts";
import {container} from "tsyringe";

createRoot(document.getElementById('root')!).render(
    <StrictMode>
        <ProveedorDeInyecciones value={container}>
            <App/>
        </ProveedorDeInyecciones>
    </StrictMode>,
);