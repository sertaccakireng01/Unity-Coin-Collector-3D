Coin Collector Game with Unity 3D

YouTube GamePlay Video Link: https://youtu.be/kuC5KdDw1WY

A specialized 3D platformer project developed with Unity 6, focusing on fundamental game design patterns, physics-based interactions, and modern C# scripting standards.

In Coin Collector, players control a capsule-shaped character in a vibrant 3D environment. The core objective is to collect all gold coins scattered throughout the map within a strict time limit while avoiding lethal hazards.

Key Mechanics:

Health System: Starting with 3 HP, players must avoid red "Hazard/Enemy" objects.

Time Trial: A dynamic countdown timer adds pressure; failing to finish in time results in a Game Over.

Win/Loss Logic: Comprehensive state management that checks for coin completion, health status, and time remaining.

Technical Implementation & Features:

Modern Scripting (Unity 6)
API Adaptation: To meet modern standards, we replaced deprecated methods (like FindObjectOfType) with the updated FindFirstObjectByType for better performance and compatibility in Unity 6.

Script Communication: Implemented a robust communication bridge between Coin scripts and the GameManager to track game state in real-time.

Physics & Hierarchy Management
Trigger vs. Collision: Demonstrated clear usage of OnTriggerEnter for collectibles (coins) and OnCollisionEnter for solid obstacles (hazards).

Camera Logic: Solved the "No Cameras Rendering" bug by implementing a logic that un-parents the camera before the player object is destroyed upon death.

UI & UX Design
Dynamic HUD: Real-time tracking of Score, Health, and Time.

Menu Systems: Complete UI flow including a Main Menu, Settings (with volume control), and a Pause Menu.

State Feedback: Used SetActive logic to trigger Win/Loss panels based on game outcomes.

Installation & Build

If you want to try the build of the game:

Go to the Releases section on the right.

Download the latest .zip file.

Unzip the archive and run the .exe file!
