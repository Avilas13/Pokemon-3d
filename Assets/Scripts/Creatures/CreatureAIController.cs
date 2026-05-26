using UnityEngine;

namespace Pokemon3D.Creatures
{
    public enum CreatureAIState { Wandering, Sleeping, Hunting, Fleeing, Socializing }

    public sealed class CreatureAIController : MonoBehaviour
    {
        [SerializeField] private CreatureAIState state;
        [SerializeField] private float temperament = 0.5f;

        public void TickAi(float dangerLevel, float hungerLevel, bool isNight)
        {
            if (dangerLevel > 0.8f)
            {
                state = CreatureAIState.Fleeing;
                return;
            }

            if (isNight && hungerLevel < 0.2f)
            {
                state = CreatureAIState.Sleeping;
                return;
            }

            if (hungerLevel > 0.7f)
            {
                state = CreatureAIState.Hunting;
                return;
            }

            state = temperament > 0.6f ? CreatureAIState.Socializing : CreatureAIState.Wandering;
        }
    }
}
