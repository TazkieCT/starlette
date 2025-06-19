<div align="center" style="position:relative;">
  <div style="position:absolute; top:0; left:0; width:100%; height:100%; z-index:-1; overflow:hidden;">
    <div style="position:absolute; width:2px; height:2px; background:white; border-radius:50%;" class="star"></div>
    <div style="position:absolute; width:3px; height:3px; background:white; border-radius:50%;" class="star"></div>
    <div style="position:absolute; width:1px; height:1px; background:white; border-radius:50%;" class="star"></div>
    <div style="position:absolute; width:60px; height:2px; background:linear-gradient(90deg, rgba(255,255,255,0), white); transform:rotate(-45deg);" class="shooting-star"></div>
    <div style="position:absolute; width:80px; height:2px; background:linear-gradient(90deg, rgba(255,255,255,0), white); transform:rotate(-45deg);" class="shooting-star"></div>
  </div>

  <div style="position:relative; z-index:1;">
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
  @keyframes twinkle {
    0% { opacity: 0.2; }
    50% { opacity: 1; }
    100% { opacity: 0.2; }
  }
  
  @keyframes shoot {
    0% { 
      transform: translateX(0) translateY(0) rotate(-45deg);
      opacity: 0;
    }
    10% { opacity: 1; }
    100% { 
      transform: translateX(1000px) translateY(1000px) rotate(-45deg);
      opacity: 0;
    }
  }
  
  .star {
    animation: twinkle 3s infinite;
  }
  
  .shooting-star {
    animation: shoot 5s infinite;
    top: -100px;
    left: -100px;
  }
  
  .shooting-star:nth-child(5) {
    animation-delay: 2s;
    top: 30%;
    left: -50px;
  }
  
  .shooting-star:nth-child(6) {
    animation-delay: 4s;
    top: 70%;
    left: -200px;
  }
</style>