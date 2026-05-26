using System;
using System.IO;
using UnityEngine;

namespace Pokemon3D.Save
{
    [Serializable]
    public sealed class SaveSnapshot
    {
        public string playerName = "Trainer";
        public string currentRegion = "StarterPlains";
        public int playSeconds;
    }

    public sealed class SaveSystem
    {
        private const string SaveFileName = "savegame.json";

        public void Save(SaveSnapshot snapshot)
        {
            var path = Path.Combine(Application.persistentDataPath, SaveFileName);
            File.WriteAllText(path, JsonUtility.ToJson(snapshot, true));
        }

        public SaveSnapshot LoadOrDefault()
        {
            var path = Path.Combine(Application.persistentDataPath, SaveFileName);
            if (!File.Exists(path)) return new SaveSnapshot();
            return JsonUtility.FromJson<SaveSnapshot>(File.ReadAllText(path));
        }
    }
}
