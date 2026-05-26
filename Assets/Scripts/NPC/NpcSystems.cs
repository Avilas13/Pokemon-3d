namespace Pokemon3D.NPC
{
    public enum NpcRole { Trainer, Shopkeeper, QuestGiver }

    public sealed class NpcProfile
    {
        public string id = string.Empty;
        public NpcRole role;
        public string dialogueRoot = "intro";
    }

    public sealed class RandomWorldEvent
    {
        public string id = string.Empty;
        public string description = string.Empty;
        public int minimumWorldLevel;
    }
}
