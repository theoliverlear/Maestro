import { container, type DependencyContainer } from 'tsyringe';
import {
    type Context,
    createContext,
    type ProviderExoticComponent, type ProviderProps, useContext
} from 'react';

const ContextoDeInyección: Context<DependencyContainer> = createContext<DependencyContainer>(container);

export const ProveedorDeInyecciones: ProviderExoticComponent<ProviderProps<DependencyContainer>> = ContextoDeInyección.Provider;
export const usarInyección: () => DependencyContainer = (): DependencyContainer => useContext(ContextoDeInyección);

export function usarInyectar<T>(nombreClase: new (...args: any[]) => T): T {
    return usarInyección().resolve<T>(nombreClase);
}