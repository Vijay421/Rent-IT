import { defineConfig } from "cypress";
import customViteConfig from "./vite.config.js";

export default defineConfig({
  component: {
    experimentalRunAllSpecs: true,
    devServer: {
      framework: "react",
      bundler: "vite",
      viteConfig: customViteConfig,
    },
    supportFile: "cypress/support/component.js",
  },

  e2e: {
    baseUrl: "http://localhost:5173",
    experimentalRunAllSpecs: true,
    setupNodeEvents(on, config) {
      // implement node event listeners here
    },
  },
});
