# Bappy Flirb

A simple arcade game, created from my [Unity 2D Jam Template](https://github.com/peabnuts123/Unity-2D-Jam-Template). It is the first game written for my other project [Pet Game](https://github.com/peabnuts123/pet-game). It will be used to make a proof of concept for hosting games on the website. Players will be able to submit their scores for points, and to record scores on a leaderboard.

For now this project is very simple and empty. In the coming weeks it will be developed into more of a real game.

## Running the project

## Testing the build output

### Prerequisites

 - Unity (obviously), to build the project
 - Node.js & npm (to serve the static assets with correct headers)

 Make sure you have installed npm dependencies by running
 ```shell
 npm install
 ```

### Running

To debug the WebGL output:

1. Make sure you have produced a build from Unity. Open Build Settings and select target WebGL, then click `Build` - select the `build` directory (in the project root) as the output for the build
1. Once the build is complete, run `npm run debug-build` to launch a server that serves the app.