using System.Collections.Generic;
using System.Linq;
using Pokemon3D.Data;
using UnityEngine;

namespace Pokemon3D.Creatures
{
    public sealed class CreatureDatabase : MonoBehaviour
    {
        [SerializeField] private TextAsset creatureJson = default!;

        private readonly Dictionary<string, CreatureDefinition> _byId = new();

        public IReadOnlyDictionary<string, CreatureDefinition> Creatures => _byId;

        private void Awake()
        {
            var parsed = JsonUtility.FromJson<CreatureList>(creatureJson.text);
            _byId.Clear();
            foreach (var creature in parsed.creatures)
            {
                _byId[creature.id] = creature;
            }
        }

        public CreatureDefinition? GetById(string id) => _byId.TryGetValue(id, out var creature) ? creature : null;

        public IEnumerable<CreatureDefinition> GetByBiomeAndConditions(string biome, string weather, string timeWindow)
        {
            return _byId.Values.Where(c =>
                c.spawnLocations.Exists(rule =>
                    rule.biome == biome && rule.weather.Contains(weather) && rule.timeWindows.Contains(timeWindow)));
        }
    }
}
