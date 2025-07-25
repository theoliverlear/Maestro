import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';

// https://vite.dev/config/
export default defineConfig({

    plugins: [
        react()
    ],
    cacheDir: './node_modules/.vite',
    css: {
        preprocessorOptions: {
            scss: {
                // silenceDeprecations: ['import'],
            },
        },
    },
})
