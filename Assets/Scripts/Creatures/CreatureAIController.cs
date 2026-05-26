using UnityEngine;

namespace Pokemon3D.Creatures
{
    public enum CreatureAiState { Wandering, Sleeping, Hunting, Fleeing, Socializing }

    public sealed class CreatureAIController : MonoBehaviour
    {
        [SerializeField] private CreatureAiState state;
        [SerializeField] private float temperament = 0.5f;

        public void TickAi(float dangerLevel, float hungerLevel, bool isNight)
        {
            if (dangerLevel > 0.8f)
            {
                state = CreatureAiState.Fleeing;
                return;
            }

            if (isNight && hungerLevel < 0.2f)
            {
                state = CreatureAiState.Sleeping;
                return;
            }

            if (hungerLevel > 0.7f)
            {
                state = CreatureAiState.Hunting;
                return;
            }

            state = temperament > 0.6f ? CreatureAiState.Socializing : CreatureAiState.Wandering;
        }
    }
}
