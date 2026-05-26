using Pokemon3D.Creatures;
using Pokemon3D.Core;
using Pokemon3D.World;
using UnityEngine;

namespace Pokemon3D
{
    public sealed class GameBootstrap : MonoBehaviour
    {
        [SerializeField] private CreatureDatabase creatureDatabase = default!;
        [SerializeField] private WorldTimeWeatherSystem worldTimeWeatherSystem = default!;
        [SerializeField] private BiomeSpawnSystem biomeSpawnSystem = default!;

        private GameplayEventBus _eventBus = default!;

        private void Awake()
        {
            _eventBus = new GameplayEventBus();
            worldTimeWeatherSystem.Initialize(_eventBus);

            // Hooks for additional systems:
            _eventBus.Subscribe<TimeWeatherChangedEvent>(_ =>
            {
                var spawnCandidatesExample = biomeSpawnSystem.GetSpawnCandidates("Forest", "Clear", worldTimeWeatherSystem.GetTimeWindow());
                _ = spawnCandidatesExample;
            });
        }
    }
}
