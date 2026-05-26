using Pokemon3D.Data;
using UnityEngine;

namespace Pokemon3D.Capture
{
    public sealed class CaptureSystem
    {
        public float ComputeCaptureChance(CreatureDefinition creature, float currentHealthPercent, int ballModifier, float temperamentFactor, float environmentBonus)
        {
            var healthFactor = Mathf.Clamp01(1f - currentHealthPercent);
            var rarityPenalty = Mathf.Clamp01(1f - (creature.rarity / 100f));
            var baseRate = creature.baseCaptureRate;
            var finalChance = baseRate * (0.35f + healthFactor) * rarityPenalty * (1f + (ballModifier / 100f));
            finalChance *= (1f - temperamentFactor * 0.25f);
            finalChance *= (1f + environmentBonus);
            return Mathf.Clamp01(finalChance);
        }

        public bool TryCapture(float chance) => Random.value <= chance;
    }
}
