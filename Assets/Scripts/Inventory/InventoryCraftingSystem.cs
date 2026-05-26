using System.Collections.Generic;

namespace Pokemon3D.Inventory
{
    public sealed class InventoryCraftingSystem
    {
        private readonly Dictionary<string, int> _items = new();

        public int GetCount(string itemId) => _items.TryGetValue(itemId, out var count) ? count : 0;

        public void AddItem(string itemId, int count)
        {
            if (!_items.ContainsKey(itemId)) _items[itemId] = 0;
            _items[itemId] += count;
        }

        public bool ConsumeItem(string itemId, int count)
        {
            if (GetCount(itemId) < count) return false;
            _items[itemId] -= count;
            return true;
        }

        public bool Craft(string outputItemId, int outputCount, IReadOnlyDictionary<string, int> recipe)
        {
            foreach (var requirement in recipe)
            {
                if (GetCount(requirement.Key) < requirement.Value) return false;
            }

            foreach (var requirement in recipe)
            {
                ConsumeItem(requirement.Key, requirement.Value);
            }

            AddItem(outputItemId, outputCount);
            return true;
        }
    }
}
