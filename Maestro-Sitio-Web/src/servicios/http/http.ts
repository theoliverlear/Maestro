import axios, {type AxiosInstance, type InternalAxiosRequestConfig} from 'axios';

export const http: AxiosInstance = axios.create({
    baseURL: import.meta.env.VITE_API_URL || 'http://localhost:30117/api',
    timeout: 10_000,
});

http.interceptors.request.use((config: InternalAxiosRequestConfig): InternalAxiosRequestConfig => {
    const token: string | null = localStorage.getItem('jwt');
    if (token) {
        config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
});