/** @type {HTMLCanvasElement} */
const canvasEl = document.querySelector('#unity-canvas');

updateCanvasSize();

const DEBOUNCE_TIME_MS = 30;
/** @type {Date} */
// let lastResizeTime = null;
/** @type {number} */
let lastResizeTimer = null;

window.onresize = function () {
  // Clear any existing timeout (cancel last action)
  clearTimeout(lastResizeTimer);
  // Queue action `DEBOUNCE_TIME_MS` ms from now
  lastResizeTimer = setTimeout(function() {
    updateCanvasSize();
  }, DEBOUNCE_TIME_MS);
};

function updateCanvasSize() {
  console.log(`Resizing canvas`);
  canvasEl.style['width'] = `${window.innerWidth}px`;
  canvasEl.style['height'] = `${window.innerHeight}px`;
}
