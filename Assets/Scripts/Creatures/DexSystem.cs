using System.Collections.Generic;

namespace Pokemon3D.Creatures
{
    public sealed class DexSystem
    {
        private readonly HashSet<string> _seen = new();
        private readonly HashSet<string> _captured = new();

        public void MarkSeen(string creatureId) => _seen.Add(creatureId);
        public void MarkCaptured(string creatureId)
        {
            _seen.Add(creatureId);
            _captured.Add(creatureId);
        }

        public bool IsSeen(string creatureId) => _seen.Contains(creatureId);
        public bool IsCaptured(string creatureId) => _captured.Contains(creatureId);
    }
}
