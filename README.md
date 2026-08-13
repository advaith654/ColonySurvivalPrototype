# \# Colony Survival Prototype

# 

# A small colony survival simulation prototype built in Unity.

# 

# The prototype demonstrates data-driven configuration using JSON, a pure C# simulation layer, Unity UI integration, and automatic game-day progression.

# 

# \## Unity Version

# 

# Unity 2022.3.62f1

# 

# \## How to Run

# 

# 1\. Open the project in Unity.

# 2\. Open the `ColonySurvival` scene.

# 3\. Press Play.

# 4\. The simulation automatically advances by one game day every real-time second.

# 

# \## Simulation

# 

# The colony tracks:

# 

# \- Villager count

# \- Food

# \- Water

# \- Food consumption

# \- Water consumption

# \- Current game day

# 

# Each game day:

# 

# \- Food is consumed based on the number of villagers.

# \- Water is consumed based on the number of villagers.

# \- Resources cannot fall below zero.

# \- The game day counter increases by one.

# 

# The colony is considered starving when either food or water reaches zero.

# 

# \## Configuration

# 

# Simulation starting values and consumption rates are stored in JSON files.

# 

# \### Population Configuration

# 

# The population configuration contains:

# 

# \- Villager count

# \- Starting food

# \- Starting water

# 

# \### Consumption Configuration

# 

# The consumption configuration contains:

# 

# \- Food consumed per villager per day

# \- Water consumed per villager per day

# 

# These values are loaded at runtime and passed into the simulation.

# 

# \## Architecture

# 

# The project separates simulation logic from Unity-specific behaviour.

# 

# ```text

# JSON Configuration

# &#x20;       ↓

# Configuration Data Classes

# &#x20;       ↓

# ColonySimulation

# &#x20;       ↓

# ColonyGameManager

# &#x20;       ↓

# Unity UI

