<div class="animated-starlette-bg">
  <div class="content-overlay">
    <h1>🌟 Starlette - An Educational Puzzle Game</h1>

    <p><strong>Starlette</strong> is an engaging 2D escape room puzzle game that subtly teaches players programming logic through interactive challenges. Inspired by commercial-quality games, Starlette disguises learning in fun mechanics—perfect for players who "accidentally" learn while having fun!</p>

    <hr class="divider">

    <h2>🎮 Game Overview</h2>

    <blockquote>"A game you play for fun, but end up learning to code!"</blockquote>

    <p>Starlette places the player inside a mysterious digital lab where the only way out is through solving logic-based puzzles. The catch? Each puzzle represents a fundamental programming concept—like loops, conditionals, variables, and operators—all hidden beneath an intuitive block-based system.</p>

    <hr class="divider">

    <h2>🧩 Features</h2>

    <ul class="features-list">
      <li>🧠 Logic puzzles that reflect actual programming constructs</li>
      <li>🧱 Guided block-based coding system (similar to Scratch)</li>
      <li>🎯 Progressively challenging levels</li>
      <li>🔐 Account system with Firebase authentication</li>
      <li>🎨 Clean UI/UX using Unity + React</li>
      <li>🚀 Educational goals wrapped in fun gameplay</li>
    </ul>

    <hr class="divider">

    <h2>🖼️ Screenshots</h2>

    <div class="screenshots">
      <img src="images/MainMenuGuide.png" alt="Main Menu">
      <img src="images/MokkaDeviceExample.jpg" alt="Mokka Device">
      <img src="images/Custscene.jpg" alt="Game CutScene">
    </div>

    <hr class="divider">

    <h2>🛠️ Built With</h2>

    <ul class="tech-list">
      <li><strong>Unity</strong> – game engine for core game logic and visuals</li>
      <li><strong>React.js</strong> – frontend interface (if applicable)</li>
      <li><strong>Express.js / Go / Rust</strong> – backend API (choose one based on your stack)</li>
      <li><strong>Firebase</strong> – user authentication and cloud data storage</li>
      <li><strong>Figma / Canva</strong> – UI/UX prototyping</li>
    </ul>

    <hr class="divider">

    <h2>🚀 Getting Started</h2>

    <h3>📦 Clone the Repository</h3>

    <pre><code>git clone https://github.com/yourusername/starlette-game.git
cd starlette-game</code></pre>

    <h3>or install the game:</h3>
    <a href="https://starlette-web-shxg.vercel.app/" class="install-link">https://starlette-web-shxg.vercel.app/</a>
  </div>
</div>

<style>
  @import url('https://fonts.googleapis.com/css2?family=Roboto:wght@300;400;500;700&display=swap');
  
  .animated-starlette-bg {
    background: 
      url('images/pixil-gif-drawing.gif') center/cover,
      radial-gradient(ellipse at center, #3a0ca3 0%, #000000 100%);
    min-height: 100vh;
    padding: 2rem;
    position: relative;
    overflow: hidden;
    font-family: 'Roboto', sans-serif;
  }

  .content-overlay {
    background: rgba(15, 23, 42, 0.85); 
    backdrop-filter: blur(8px);
    border: 1px solid rgba(76, 201, 240, 0.5);
    border-radius: 16px;
    padding: 2.5rem;
    max-width: 900px;
    margin: 2rem auto;
    position: relative;
    z-index: 2;
    box-shadow: 0 0 30px rgba(76, 201, 240, 0.3);
    color: #f8f9fa;
    line-height: 1.6;
  }

  h1, h2, h3 {
    color: #4cc9f0;
    margin-top: 1.5em;
  }

  h1 {
    font-size: 2.5rem;
    text-align: center;
    margin-bottom: 1.5rem;
  }

  h2 {
    font-size: 1.8rem;
    border-bottom: 1px solid rgba(76, 201, 240, 0.3);
    padding-bottom: 0.5rem;
  }

  h3 {
    font-size: 1.4rem;
  }

  .divider {
    border: 0;
    height: 1px;
    background: linear-gradient(to right, transparent, rgba(76, 201, 240, 0.5), transparent);
    margin: 2rem 0;
  }

  blockquote {
    border-left: 4px solid #4cc9f0;
    padding-left: 1rem;
    margin: 1.5rem 0;
    font-style: italic;
    color: #d1d5db;
  }

  .features-list, .tech-list {
    padding-left: 1.5rem;
  }

  .features-list li, .tech-list li {
    margin-bottom: 0.8rem;
  }

  .screenshots {
    display: flex;
    flex-direction: column;
    align-items: center;
    gap: 1.5rem;
    margin: 2rem 0;
  }

  .screenshots img {
    max-width: 100%;
    height: auto;
    border-radius: 8px;
    border: 1px solid rgba(76, 201, 240, 0.3);
    box-shadow: 0 4px 15px rgba(0, 0, 0, 0.3);
  }

  pre {
    background: rgba(0, 0, 0, 0.3);
    padding: 1rem;
    border-radius: 6px;
    overflow-x: auto;
    border: 1px solid rgba(76, 201, 240, 0.2);
  }

  code {
    font-family: 'Courier New', monospace;
    color: #f8f9fa;
  }

  .install-link {
    display: inline-block;
    color: #4cc9f0;
    text-decoration: none;
    margin: 1rem 0;
    padding: 0.5rem 1rem;
    border: 1px solid #4cc9f0;
    border-radius: 4px;
    transition: all 0.3s ease;
  }

  .install-link:hover {
    background: rgba(76, 201, 240, 0.1);
    box-shadow: 0 0 10px rgba(76, 201, 240, 0.3);
  }

  @media (max-width: 768px) {
    .content-overlay {
      padding: 1.5rem;
      margin: 1rem;
    }
    
    h1 {
      font-size: 2rem;
    }
    
    h2 {
      font-size: 1.5rem;
    }
  }
</style>