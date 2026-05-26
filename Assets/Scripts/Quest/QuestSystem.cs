using System.Collections.Generic;
using Pokemon3D.Data;

namespace Pokemon3D.Quest
{
    public sealed class QuestSystem
    {
        private readonly Dictionary<string, QuestDefinition> _questById = new();
        private readonly HashSet<string> _activeQuests = new();

        public void Register(QuestDefinition definition) => _questById[definition.id] = definition;
        public bool StartQuest(string questId) => _questById.ContainsKey(questId) && _activeQuests.Add(questId);
        public bool IsActive(string questId) => _activeQuests.Contains(questId);

        public DialogueNode? GetDialogueNode(string questId, string nodeId)
        {
            if (!_questById.TryGetValue(questId, out var quest)) return null;
            return quest.dialogue.Find(node => node.id == nodeId);
        }
    }
}
