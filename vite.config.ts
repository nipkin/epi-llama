import { defineConfig } from 'vite';
import tailwindcss from '@tailwindcss/vite';

export default defineConfig({
    root: './',
    build: {
        outDir: 'wwwroot/dist',
        emptyOutDir: true,
    },
    plugins: [
        tailwindcss()
    ],
});