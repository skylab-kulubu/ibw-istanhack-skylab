import { defineConfig } from "vite";
import react from "@vitejs/plugin-react";

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react()],
});

// tailwind.config.js
module.exports = {
  // ...
  plugins: [
    // ...
    require("@tailwindcss/forms"),
  ],
};
