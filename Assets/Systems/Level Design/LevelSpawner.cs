using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Level Spawner", fileName = "Level Spawner")]
public class LevelSpawner : ScriptableObject
{
    public List<Spawn> totemsLevel = new List<Spawn>();

    public List<ItemInfo> GetSpawns(int index)
    {
        Spawn spawn = totemsLevel[index];
        List<ItemInfo> result = new List<ItemInfo>();

        for (int i = 0; i < spawn.types.Count; i++)
        {
            int amount = spawn.types[i].GetRandomSpawns();

            while (amount > 0)
            {
                ItemInfo itemToSpanw = spawn.types[i].type.GetRandomItem();

                result.Add(itemToSpanw);
                amount -= 1;
            }
        }

        return result;
    }

    [System.Serializable]
    public class Spawn
    {
        public List<SpawnConfig> types = new List<SpawnConfig>();
    }

    [System.Serializable]
    public class SpawnConfig
    {
        public ResourceType type;
        public int minSpawn;
        public int maxSpawn;

        public int GetRandomSpawns() => Random.Range(minSpawn, maxSpawn + 1);
    }
}
