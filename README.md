# Slot Machine Game

A classic slot machine game built with Unity 2D as part of a game development internship assignment.

---

## Game Overview

Lucky Spin is a 3-reel slot machine game where players place bets and spin the reels to win credits. The game features smooth reel animations, a dynamic credit system, and satisfying audio-visual feedback on wins.

**How to Play:**
- Press the **Bet** button to increase your bet amount
- Pull the **Handle** or press **Spin** to spin the reels
- Win credits when 2 or 3 symbols match on the payline
- 3 matching symbols = 5x your bet (Jackpot!)
- 2 matching symbols = 2x your bet

---

## How to Run the WebGL Build

1. Clone this repository
2. Navigate to the `Build/WebGL/` folder
3. Open `index.html` in a browser

> Note: Some browsers block local WebGL builds. If it doesn't load, use a local server:
> - Install VS Code + Live Server extension
> - Right click `index.html` → Open with Live Server

Or simply visit the hosted build link (if available).

---

## Bonus Features

### Celebration Particles
- A particle system triggers on a Jackpot win (3 matching symbols)
- Adds visual excitement and polish to the win experience

### Audio System
- Background music loops throughout gameplay
- Spin sound plays during reel animation
- Win sound effect triggers on successful matches
- All audio managed through a dedicated `AudioManager` singleton

### Bet System
- Players can increase their bet before each spin
- Winnings are calculated as a multiplier of the current bet
- Adds strategy and replayability to the game

---

## Thought Process & Approach

### Architecture
The game is built around a clean **singleton pattern** for core managers:
- `GameManager` — controls game state and flow using a state machine (Idle → Spinning → Evaluating → Win/Lose)
- `AudioManager` — handles all sound playback
- `ReelController` — manages individual reel spinning and symbol display

### Reel Animation
Instead of using pre-baked animations, the reel spinning is **fully code-driven** using coroutines. Each reel scrolls symbols downward at high speed, then gradually decelerates using `Mathf.Lerp` before snapping to the predetermined target symbol. This ensures the animation always looks smooth while the outcome remains truly random.

### RNG & Fairness
Random outcomes are generated using Unity's `Random.Range` before the spin animation starts. The visual result always matches the predetermined random outcome — the animation is purely cosmetic.

### Win Evaluation
Win checking uses a simple but clean comparison of symbol indices across all 3 reels. Two or more matching symbols trigger a payout, with a full 3-symbol match triggering the jackpot celebration.

### Code Quality
- Singleton pattern for global managers
- Coroutines for async animation and UI updates
- `[SerializeField]` used instead of public fields where possible
- Meaningful class and variable names throughout

---
