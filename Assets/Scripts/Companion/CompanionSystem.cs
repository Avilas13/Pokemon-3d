using System.Collections.Generic;

namespace Pokemon3D.Companion
{
    public sealed class CompanionSystem
    {
        private readonly Dictionary<string, int> _friendship = new();

        public void Register(string creatureId)
        {
            if (!_friendship.ContainsKey(creatureId)) _friendship[creatureId] = 0;
        }

        public void Pet(string creatureId) => AdjustFriendship(creatureId, 2);
        public void Feed(string creatureId) => AdjustFriendship(creatureId, 4);
        public void Play(string creatureId) => AdjustFriendship(creatureId, 3);
        public bool CanRide(string creatureId) => _friendship.TryGetValue(creatureId, out var value) && value >= 50;

        private void AdjustFriendship(string creatureId, int amount)
        {
            Register(creatureId);
            _friendship[creatureId] += amount;
        }
    }
}
