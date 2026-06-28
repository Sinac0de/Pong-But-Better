# Pong! But better

A fast-paced 2D arcade pong prototype built in Unity, exploring AI difficulty scaling, power-up mechanics, and polished match flow in a small competitive package.

> This project is an in-progress prototype and proof-of-concept. It is not yet a complete game and is focused on refining gameplay systems and core mechanics.

## Overview

Pong! But better reimagines classic pong with a modern prototype mindset. The game centers on a player paddle, an AI opponent, and a small set of power-ups that change match dynamics during play.

The project currently explores core systems such as:
- Responsive paddle movement and ball physics
- AI opponent behavior with difficulty modes
- Power-ups that affect paddle size, ball speed, and enemy behavior
- Match scoring, pacing, and win condition flow
- Audio and menu-driven gameplay presentation

## Features

### Gameplay Systems
- 2D paddle control with player input handling
- Ball physics, launch mechanics, and score-based match flow
- Power-ups including Big Paddle, Fast Ball, and Slow AI
- Score manager, point handling, and basic win/lose game states
- Main menu and simple game state transitions

### AI & Design
- Adaptive AI behavior through easy, medium, and hard difficulty settings
- Hard mode predictive movement using ball velocity
- Randomized power-up spawning during gameplay
- Arcade-style pacing with repeated rally and comeback potential

### Architecture & Development
- Modular Unity C# architecture using MonoBehaviour components
- Singleton-based managers for game state, scoring, and audio
- Clear separation of concerns across gameplay, AI, UI, and power-up systems
- 2D physics-driven gameplay built on Unity's physics stack

## Project Status

This repository represents an early-stage prototype rather than a finished product.

Current status:
- Core paddle and ball gameplay implemented
- AI difficulty modes and opponent behavior present
- Power-up spawning and effect handling functional
- Menu flow, audio, and scoring systems in place
- Additional polish, visuals, and expanded feature content remain in progress

## Technologies Used

- Unity 2D
- C#
- Unity Input System
- TextMeshPro
- 2D physics and UI systems

## Project Structure

- Assets/Scripts/ — gameplay, AI, and system scripts
- Assets/Scripts/UI/ — user interface components
- Assets/Prefabs/ — ball, paddles, power-ups, and UI prefabs
- Assets/Music/ — audio assets and music
- Assets/Scenes/ — scene layouts for menu and gameplay

## Future Direction

Planned areas for growth include:
- Improved AI balancing and more nuanced opponent behavior
- Expanded power-up variety and visual feedback
- More polished menus, UI transitions, and match presentation
- Additional gameplay modes or multiplayer support
- Enhanced audio, particle effects, and overall polish


