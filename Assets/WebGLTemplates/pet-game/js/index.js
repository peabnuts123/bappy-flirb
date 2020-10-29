console.log("index.js");
console.log("PRODUCT_NAME: {{{PRODUCT_NAME}}}")

const loadConfig = {
  dataUrl: `Build/${UnityConfig.DATA_FILENAME}`,
  frameworkUrl: `Build/${UnityConfig.FRAMEWORK_FILENAME}`,
  codeUrl: `Build/${UnityConfig.CODE_FILENAME}`,
  streamingAssetsUrl: `StreamingAssets`,
  companyName: UnityConfig.COMPANY_NAME,
  productName: UnityConfig.PRODUCT_NAME,
  productVersion: UnityConfig.PRODUCT_VERSION,
}

if (UnityConfig.MEMORY_FILENAME) {
  loadConfig.memoryUrl = `Build/${UnityConfig.MEMORY_FILENAME}`;
}

if (UnityConfig.SYMBOLS_FILENAME) {
  loadConfig.symbolsUrl = `Build/${UnityConfig.SYMBOLS_FILENAME}`;
}

createUnityInstance(document.getElementById("unity-canvas"), loadConfig, function (progress) {
  console.log(`Loading... ${progress * 100}%`);
});