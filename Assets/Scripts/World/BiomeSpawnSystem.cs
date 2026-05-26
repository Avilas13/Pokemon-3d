using System.Collections.Generic;
using Pokemon3D.Creatures;
using UnityEngine;

namespace Pokemon3D.World
{
    public sealed class BiomeSpawnSystem : MonoBehaviour
    {
        [SerializeField] private CreatureDatabase database = default!;

        public IEnumerable<string> GetSpawnCandidates(string biome, string weather, string timeWindow)
        {
            foreach (var creature in database.GetByBiomeAndConditions(biome, weather, timeWindow))
            {
                yield return creature.id;
            }
        }
    }
}
