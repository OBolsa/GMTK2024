using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Level Spawner", fileName = "Level Spawner")]
public class LevelSpawner : ScriptableObject
{
    public List<SpawnConfig> configs = new List<SpawnConfig>();
}

[System.Serializable]
public class SpawnConfig
{
    public int spawnAmountPerResource;
    public bool spawnItemsWithBuff;
    public float buildTimerInSeconds;
}