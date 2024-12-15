# Spot-the-diff
A dynamic "Spot the Difference" game built with Unity. The game loads its data (images and differences) from a JSON file, allowing easy customization and updates without changing the game logic.
#Built in 1 Day
## Playable Game Here

You can find the source code for this project at the following GitHub repository:

[Spot-the-Diff Source Code](https://github.com/Devansh-Rawat-gamedev/Spot-the-diff)

## Description

This game challenges players to spot the differences between two images. The game is designed to dynamically load the images and their differences from a JSON file, making it easy to add new levels and modify the differences without altering the game code.

### How It Works

- The game reads a JSON file that contains:
  - Image paths
  - Coordinates and dimensions of the differences between the images
- The game presents two images and overlays clickable areas where the differences are located.
- When a player clicks on the correct difference, the score increases.
- The game is built with Unity, and it uses UI elements like images, buttons, and text for interactivity.

## Features

- **Dynamic Image and Difference Loading**: The game loads images and their corresponding differences from a JSON file.
- **Score System**: Players earn points by finding the differences.
- **Timer**: The game includes a timer that tracks how long the player takes to find all differences.
- **Future AI Integration**: Future plans include integrating AI to automatically generate JSON files with image differences, making it easier to add new levels.

## How to Play

1. Open the game and start a new level.
2. Look at the two images displayed on the screen.
3. Click on the areas where you think the differences between the images are located.
4. Once you find all the differences, your score will increase, and the next level will load (if available).

## Future Plans

- **AI Integration**: Integrate AI to automatically generate the JSON files, including the differences between images. This will help automate the creation of new levels and enhance the game's scalability.

## Getting Started

### Prerequisites

To run this project locally, you'll need the following:

- Unity (version used: [insert Unity version])
- A compatible web browser or Unity editor for testing

### Installation

1. Clone this repository to your local machine:

   ```bash
   git clone https://github.com/Devansh-Rawat-gamedev/Spot-the-diff.git
