# Brew Time ☕  
### 2D Drink-Making Simulation Game (Unity)

**Brew Time** is a 2D drink-making simulation game developed in **Unity (C#)**.  
The project focuses on **interactive UI systems**, **event-driven gameplay logic**, and **data-driven order validation**, rather than graphics or narrative design.

Players fulfill dynamically generated drink orders by dragging ingredients across multiple stations under time constraints, progressing through different gameplay states such as active play, level-up, and failure screens.

---

## 🎮 Gameplay Overview

- Orders are generated dynamically based on predefined recipes
- Players assemble drinks by:
  - Selecting ingredients
  - Adjusting quantities
  - Using different preparation stations
- Orders are validated in real time against expected recipes
- Mistakes or timeouts result in penalties or failure states

---

## ✨ Key Features

- **Multi-state UI system**
  - Gameplay
  - Level-up screen
  - Lose/failure screen
  - UI visibility controlled through script-driven state transitions

- **Order & recipe management**
  - Orders represented as structured data objects
  - Recipe comparison handled through centralized validation logic

- **Drag-and-drop interaction**
  - Implemented using Unity `EventSystem` interfaces  
    (`IBeginDragHandler`, `IDragHandler`, `IDropHandler`)
  - Reusable draggable components across ingredients and tools

- **Timer & progression logic**
  - Orders include countdown timers
  - Time pressure affects success and failure outcomes

- **Prefab-based architecture**
  - Stations, ingredients, UI elements built as reusable prefabs
  - Clean separation between visuals and logic

- **Custom UI & sprite workflow**
  - Hand-drawn sprite sheet sliced with Unity Sprite Editor
  - Integrated into UI using `Canvas`, `Image`, `Slider`, and layout groups

---

## 🛠 Tech Stack

- **Engine:** Unity 6  
- **Language:** C#  
- **UI:** Unity UI (Canvas, Image, Slider, Grid/Layout Groups)  
- **Input:** Unity EventSystem & Input System  
- **Architecture:** Prefabs, component-based design

---

## 📁 Project Structure

```text
├── Assets
├── Packages
├── ProjectSettings
├── Demo   
├── README.md
```
## 📷 Demo
### Gameplay
![Gameplay](Demo\BrewTime.mp4)
