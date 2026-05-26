# Pokemon-3d

A modern, stylized-anime, open-world monster-collection game foundation for **Unity HDRP** with data-driven systems and multiplayer-ready architecture.

## Implemented foundation

- Third-person movement baseline (`Assets/Scripts/Player/PlayerController3D.cs`) with sprint and jump hooks for climbing/swimming state extensions.
- Seamless world systems foundation:
  - Day/night + dynamic weather (`Assets/Scripts/World/WorldTimeWeatherSystem.cs`)
  - Biome/time/weather spawn queries (`Assets/Scripts/World/BiomeSpawnSystem.cs`)
  - Object pooling utility (`Assets/Scripts/World/ObjectPool.cs`)
- Creature lifecycle:
  - 50 unique creatures with stats, types, abilities, evolution rules, animation/sfx references, personality, spawn locations, and shiny flags (`Assets/Data/Creatures/creatures.json`)
  - Runtime creature data loading (`Assets/Scripts/Creatures/CreatureDatabase.cs`)
  - Wild AI state model (wander, sleep, hunt, flee, socialize) (`Assets/Scripts/Creatures/CreatureAIController.cs`)
  - Dex tracking (`Assets/Scripts/Creatures/DexSystem.cs`)
- Capture mechanics (`Assets/Scripts/Capture/CaptureSystem.cs`) with health/rarity/temperament/environment modifiers.
- Turn-based battle example (`Assets/Scripts/Battle/TurnBasedBattleSystem.cs`) including:
  - Type effectiveness
  - Status placeholders
  - XP/level up
  - Evolution check
- Companion interaction system (`Assets/Scripts/Companion/CompanionSystem.cs`) for pet/feed/play/ride friendship progression.
- Inventory + crafting core (`Assets/Scripts/Inventory/InventoryCraftingSystem.cs`) with sample items (`Assets/Data/Items/items.json`).
- NPC and world-event models (`Assets/Scripts/NPC/NpcSystems.cs`).
- Quest/dialogue system scaffolding with branching dialogue (`Assets/Scripts/Quest/QuestSystem.cs`, `Assets/Data/Quests/quests.json`).
- Save/load snapshot framework (`Assets/Scripts/Save/SaveSystem.cs`) including autosave-compatible model.
- Event-driven architecture (`Assets/Scripts/Core/GameplayEventBus.cs`) and bootstrap wiring (`Assets/Scripts/Core/GameBootstrap.cs`).
- Multiplayer-ready abstractions for replication and trading (`Assets/Scripts/Networking/MultiplayerInterfaces.cs`).
- HUD controller + JRPG-inspired UI mockup (`Assets/Scripts/UI/HudController.cs`, `Assets/UI/Mockups/HUD_Mockup.html`).

## Project structure

```text
Assets/
  Data/
    Creatures/creatures.json
    Items/items.json
    Quests/quests.json
    Spawns/spawn_tables.json
  Scripts/
    Battle/
    Capture/
    Companion/
    Core/
    Creatures/
    Data/
    Inventory/
    Networking/
    NPC/
    Player/
    Quest/
    Save/
    UI/
    World/
  UI/
    Mockups/HUD_Mockup.html
```

## Setup

1. Create a **Unity 2022.3+ HDRP** project.
2. Copy this repository contents into the Unity project root (`Assets/` paths are already organized).
3. Import TextAssets for JSON files under `Assets/Data/**`.
4. Create a bootstrap scene and add:
   - `GameBootstrap`
   - `CreatureDatabase` (assign `creatures.json`)
   - `WorldTimeWeatherSystem`
   - `BiomeSpawnSystem` (assign `CreatureDatabase`)
5. Add a player GameObject with `CharacterController` + `PlayerController3D`.
6. Create HUD Canvas and wire references in `HudController`.

## Extending the creature roster

1. Add new creature entries to `Assets/Data/Creatures/creatures.json` under `creatures`.
2. Provide:
   - `stats`
   - `types`
   - `abilities`
   - `evolutionChain`
   - `animations`
   - `soundEffects`
   - `personality`
   - `spawnLocations`
   - `hasShinyVariant`, `rarity`, `baseCaptureRate`
3. Add corresponding animation clips, SFX assets, and prefabs named consistently with the IDs.
4. Optionally tune biome rates in `Assets/Data/Spawns/spawn_tables.json`.

## Notes on optimization and scalability

- `ObjectPool<T>` is included for pooled creature/NPC instances.
- Spawn queries are biome/time/weather constrained for low-cost filtering.
- Event bus supports clean decoupling and future network authority syncing.
- Interfaces in `Networking/` allow co-op/trading implementation without rewriting gameplay systems.

## Audio direction (implementation hook)

Use region- and time-sensitive mixers by subscribing to `TimeWeatherChangedEvent` and biome transitions to blend ambient and battle tracks.
