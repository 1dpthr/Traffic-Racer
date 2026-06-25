# Traffic Racer

A 3D traffic racing game built with Unity.

## 🎮 Game Features

- **Endless Racing**: Drive through traffic and avoid collisions
- **Multiple Vehicles**: Choose from various car models
- **Traffic System**: Dynamic traffic with multiple vehicle types
- **Score System**: Earn points by driving and avoiding traffic
- **Smooth Controls**: Responsive car controls and camera follow system
- **Garage System**: Car selection feature

## 🚗 Gameplay

- Drive your car through busy traffic
- Avoid collisions with other vehicles
- Score points based on distance traveled
- Challenge yourself to achieve the highest score

## 🛠️ Built With

- **Unity** - Game Engine
- **C#** - Programming Language
- **TextMesh Pro** - Text rendering

## 📁 Project Structure

```
Assets/
├── Animation/          # Camera and UI animations
├── Azerilo/           # Car models and city scene assets
├── Garage Assets/     # Garage environment
├── Material/          # Game materials
├── Prefab/           # Player car, traffic vehicles, transitions
├── Scenes/           # Game scenes (Garage, Level01, MainMenu)
├── Scripts/          # Game logic scripts
│   ├── CameraMovement.cs
│   ├── CarController.cs
│   ├── CarSelection.cs
│   ├── CarSpawner.cs
│   ├── TrafficManager.cs
│   ├── UiManager.cs
│   └── ...
└── TextMesh Pro/     # Text rendering assets
```

## 🎯 How to Play

1. Clone or download the repository
2. Open the project in Unity (2021.3 or later recommended)
3. Open the MainManu scene or Level01 scene
4. Press Play to start the game

## 🎮 Controls

- **W/Up Arrow**: Accelerate
- **S/Down Arrow**: Brake/Reverse
- **A/Left Arrow**: Move Left
- **D/Right Arrow**: Move Right

## 📝 Scripts Overview

- **CarController.cs**: Handles player car movement and physics
- **TrafficManager.cs**: Manages traffic vehicle spawning and behavior
- **CarSpawner.cs**: Spawns traffic vehicles
- **UiManager.cs**: Manages game UI and score
- **CameraMovement.cs**: Handles camera follow behavior
- **CarSelection.cs**: Garage car selection system

## 🏗️ Building the Game

To build the game for your platform:

1. Open the project in Unity
2. Go to **File > Build Settings**
3. Select your target platform (Windows, Mac, Android, etc.)
4. Click **Build And Run**

## 📄 License

This project is created for educational purposes as part of a game programming course.

## 👨‍💻 Developer

Built by 1dpthr

---

**Note**: This repository contains Unity project files. The Library and Temp folders are excluded via .gitignore to reduce repository size.