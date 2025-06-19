<div class="animated-starlette-bg">
 <div class="content-overlay">
    # 🌟 Starlette - An Educational Puzzle Game

    **Starlette** is an engaging 2D escape room puzzle game that subtly teaches players programming logic through interactive challenges. Inspired by commercial-quality games, Starlette disguises learning in fun mechanics—perfect for players who "accidentally" learn while having fun!

    ---

    ## 🎮 Game Overview

    > _"A game you play for fun, but end up learning to code!"_

    Starlette places the player inside a mysterious digital lab where the only way out is through solving logic-based puzzles. The catch? Each puzzle represents a fundamental programming concept—like loops, conditionals, variables, and operators—all hidden beneath an intuitive block-based system.

    ---

    ## 🧩 Features

    - 🧠 Logic puzzles that reflect actual programming constructs
    - 🧱 Guided block-based coding system (similar to Scratch)
    - 🎯 Progressively challenging levels
    - 🔐 Account system with Firebase authentication
    - 🎨 Clean UI/UX using Unity + React
    - 🚀 Educational goals wrapped in fun gameplay

    ---

    ## 🖼️ Screenshots

    <p align="center">
      <img src="images/MainMenuGuide.png" alt="Main Menu" width="600"/>
    </p>

    <p align="center">
      <img src="images/MokkaDeviceExample.jpg" alt="Mokka Device" width="600"/>
    </p>

    <p align="center">
      <img src="images/Custscene.jpg" alt="Game CutScene" width="600"/>
    </p>

    ---

    ## 🛠️ Built With

    - **Unity** – game engine for core game logic and visuals
    - **React.js** – frontend interface (if applicable)
    - **Express.js / Go / Rust** – backend API (choose one based on your stack)
    - **Firebase** – user authentication and cloud data storage
    - **Figma / Canva** – UI/UX prototyping

    ---

    ## 🚀 Getting Started

    ### 📦 Clone the Repository

    ```bash
    git clone https://github.com/yourusername/starlette-game.git
    cd starlette-game
    ```
    ### or install the game:
    https://starlette-web-shxg.vercel.app/
  </div>
</div>

<style>
  .animated-starlette-bg {
  background: 
    url('images/pixil-gif-drawing.gif') center/cover,
    radial-gradient(ellipse at center, #3a0ca3 0%, #000000 100%);
  min-height: 100vh;
  padding: 2rem;
  position: relative;
  overflow: hidden;
}

.content-overlay {
  background: rgba(15, 23, 42, 0.85); 
  backdrop-filter: blur(6px);
  border: 1px solid rgba(76, 201, 240, 0.5);
  border-radius: 16px;
  padding: 2.5rem;
  max-width: 900px;
  margin: 0 auto;
  position: relative;
  z-index: 2;
  box-shadow: 0 0 30px rgba(76, 201, 240, 0.2);
  color: #f8f9fa;
}


</style>