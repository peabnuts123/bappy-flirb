var UnityConfig = {
  /**
   * The Company Name defined in the Player Settings.
   * @type {string}
   */
  COMPANY_NAME: "{{{COMPANY_NAME}}}",
  /**
   * The Product Name defined in the Player Settings.
   * @type {string}
   */
  PRODUCT_NAME: "{{{PRODUCT_NAME}}}",
  /**
   * The Version defined in the Player Settings.
   * @type {string}
   */
  PRODUCT_VERSION: "{{{PRODUCT_VERSION}}}",
  /**
   * The Default Canvas Width defined in the Player Settings > Resolution and Presentation.
   * @type {number}
   */
  WIDTH: Number("{{{WIDTH}}}"),
  /**
   * The Default Canvas Height in the Player Settings > Resolution and Presentation.
   * @type {number}
   */
  HEIGHT: Number("{{{HEIGHT}}}"),
  /**
   * This is set to the “Dark” value when Splash Style Player Settings > Splash Image is set to Light on Dark, otherwise it is set to the “Light” value.
   * @type {string}
   */
  SPLASH_SCREEN_STYLE: "{{{SPLASH_SCREEN_STYLE}}}",
  /**
   * Represents the Background Color defined in a form of a hex triplet.
   * @type {string}
   */
  BACKGROUND_COLOR: "{{{BACKGROUND_COLOR}}}",
  /**
   * The Unity version.
   * @type {string}
   */
  UNITY_VERSION: "{{{UNITY_VERSION}}}",
  /**
   * This is set to true if the Development Build option is enabled.
   * @type {boolean}
   */
  DEVELOPMENT_PLAYER: Boolean("{{{DEVELOPMENT_PLAYER}}}"),
  /**
   * This is set to “Gzip” or “Brotli”, depending on which compression method is used and which decompressor is included in the build. If neither is included, the variable is set to an empty string.
   * @type {string}
   */
  DECOMPRESSION_FALLBACK: "{{{DECOMPRESSION_FALLBACK}}}",
  /**
   * The initial size of the memory heap in bytes.
   * @type {number}
   */
  TOTAL_MEMORY: Number("{{{TOTAL_MEMORY}}}"),
  /**
   * This is set to true if the current build is a WebAssembly build.
   * @type {boolean}
   */
  USE_WASM: Boolean("{{{USE_WASM}}}"),
  /**
   * This is set to true if the current build uses threads.
   * @type {boolean}
   */
  USE_THREADS: Boolean("{{{USE_THREADS}}}"),
  /**
   * This is set to true if the current build supports the WebGL1.0 graphics API.
   * @type {boolean}
   */
  USE_WEBGL_1_0: Boolean("{{{USE_WEBGL_1_0}}}"),
  /**
   * This is set to true if the current build supports the WebGL2.0 graphics API.
   * @type {boolean}
   */
  USE_WEBGL_2_0: Boolean("{{{USE_WEBGL_2_0}}}"),
  /**
   * This is set to true if the current build uses indexedDB caching for the downloaded files.
   * @type {boolean}
   */
  USE_DATA_CACHING: Boolean("{{{USE_DATA_CACHING}}}"),
  /**
   * This is set to the filename of the build loader script.
   * @type {string}
   */
  LOADER_FILENAME: "{{{LOADER_FILENAME}}}",
  /**
   * This is set to the filename of the main data file.
   * @type {string}
   */
  DATA_FILENAME: "{{{DATA_FILENAME}}}",
  /**
   * This is set to the filename of the build framework script.
   * @type {string}
   */
  FRAMEWORK_FILENAME: "{{{FRAMEWORK_FILENAME}}}",
  /**
   * This is set to the filename of the WebAssembly module when the current build is a WebAssembly build, otherwise it is set to the filename of the asm.js module.
   * @type {string}
   */
  CODE_FILENAME: "{{{CODE_FILENAME}}}",
  /**
   * This is set to the filename of the memory file when memory is stored in an external file, otherwise it is set to an empty string.
   * @type {string}
   */
  MEMORY_FILENAME: "{{{MEMORY_FILENAME}}}",
  /**
   * This is set to the filename of the JSON file containing debug symbols when the current build is using debug symbols, otherwise it is set to an empty string.
   * @type {string}
   */
  SYMBOLS_FILENAME: "{{{SYMBOLS_FILENAME}}}",
  /**
   * This is set to the filename of the background image when the background image is selected in the Player Settings > Splash Image, otherwise it is set to an empty string.
   * @type {string}
   */
  BACKGROUND_FILENAME: "{{{BACKGROUND_FILENAME}}}",
};

console.log(UnityConfig);
window.UnityConfig = UnityConfig;

/**
 * @typedef {typeof UnityConfig} UnityConfig
 */