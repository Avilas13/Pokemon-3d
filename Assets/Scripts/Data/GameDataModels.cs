using System;
using System.Collections.Generic;

namespace Pokemon3D.Data
{
    [Serializable]
    public sealed class CreatureStats
    {
        public int hp;
        public int attack;
        public int defense;
        public int specialAttack;
        public int specialDefense;
        public int speed;
    }

    [Serializable]
    public sealed class EvolutionRule
    {
        public string evolvesTo = string.Empty;
        public int levelRequirement;
        public string requiredItem = string.Empty;
    }

    [Serializable]
    public sealed class SpawnRule
    {
        public string biome = string.Empty;
        public List<string> weather = new();
        public List<string> timeWindows = new();
    }

    [Serializable]
    public sealed class CreatureDefinition
    {
        public string id = string.Empty;
        public string displayName = string.Empty;
        public CreatureStats stats = new();
        public List<string> types = new();
        public List<string> abilities = new();
        public List<EvolutionRule> evolutionChain = new();
        public List<string> animations = new();
        public List<string> soundEffects = new();
        public string personality = string.Empty;
        public List<SpawnRule> spawnLocations = new();
        public bool hasShinyVariant;
        public int rarity;
        public float baseCaptureRate;
    }

    [Serializable]
    public sealed class CreatureList
    {
        public List<CreatureDefinition> creatures = new();
    }

    [Serializable]
    public sealed class ItemDefinition
    {
        public string id = string.Empty;
        public string category = string.Empty;
        public int value;
    }

    [Serializable]
    public sealed class ItemList
    {
        public List<ItemDefinition> items = new();
    }

    [Serializable]
    public sealed class QuestObjective
    {
        public string description = string.Empty;
        public int targetCount;
    }

    [Serializable]
    public sealed class DialogueChoice
    {
        public string text = string.Empty;
        public string nextNodeId = string.Empty;
    }

    [Serializable]
    public sealed class DialogueNode
    {
        public string id = string.Empty;
        public string text = string.Empty;
        public List<DialogueChoice> choices = new();
    }

    [Serializable]
    public sealed class QuestDefinition
    {
        public string id = string.Empty;
        public string title = string.Empty;
        public bool isMainStory;
        public List<QuestObjective> objectives = new();
        public List<DialogueNode> dialogue = new();
    }

    [Serializable]
    public sealed class QuestList
    {
        public List<QuestDefinition> quests = new();
    }
}
