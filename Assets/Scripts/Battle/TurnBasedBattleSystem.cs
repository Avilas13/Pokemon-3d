using System.Collections.Generic;
using Pokemon3D.Data;
using UnityEngine;

namespace Pokemon3D.Battle
{
    public enum StatusEffect { None, Poison, Burn, Sleep, Paralysis, Freeze }

    public sealed class BattleCreatureState
    {
        public CreatureDefinition Definition = default!;
        public int Level;
        public int CurrentHp;
        public StatusEffect Status;
        public int Experience;
    }

    public sealed class TurnBasedBattleSystem
    {
        private static readonly Dictionary<string, Dictionary<string, float>> TypeChart = new()
        {
            ["Fire"] = new() { ["Grass"] = 2f, ["Water"] = 0.5f },
            ["Water"] = new() { ["Fire"] = 2f, ["Electric"] = 0.5f },
            ["Grass"] = new() { ["Water"] = 2f, ["Fire"] = 0.5f },
            ["Electric"] = new() { ["Water"] = 2f, ["Ground"] = 0.5f }
        };

        public int ComputeDamage(BattleCreatureState attacker, BattleCreatureState defender, int movePower, string moveType)
        {
            var levelScalar = (2f * attacker.Level / 5f) + 2f;
            var attack = Mathf.Max(1, attacker.Definition.stats.attack);
            var defense = Mathf.Max(1, defender.Definition.stats.defense);
            var baseDamage = ((levelScalar * movePower * attack / defense) / 50f) + 2f;

            var multiplier = 1f;
            foreach (var defenderType in defender.Definition.types)
            {
                if (TypeChart.TryGetValue(moveType, out var interactions) && interactions.TryGetValue(defenderType, out var effect))
                {
                    multiplier *= effect;
                }
            }

            return Mathf.Max(1, Mathf.RoundToInt(baseDamage * multiplier));
        }

        public bool AwardExperienceAndCheckLevelUp(BattleCreatureState creature, int xpGained)
        {
            creature.Experience += xpGained;
            var needed = creature.Level * creature.Level * 10;
            if (creature.Experience < needed)
            {
                return false;
            }

            creature.Level++;
            creature.CurrentHp = creature.Definition.stats.hp + creature.Level * 2;
            return true;
        }

        public string? TryGetEvolution(BattleCreatureState creature)
        {
            foreach (var rule in creature.Definition.evolutionChain)
            {
                if (creature.Level >= rule.levelRequirement)
                {
                    return rule.evolvesTo;
                }
            }

            return null;
        }
    }
}
