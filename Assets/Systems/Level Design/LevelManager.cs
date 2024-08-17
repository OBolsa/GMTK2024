using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public LevelSpawner spawner;
    public int totems;

    public Action<ItemInfo> OnSpawn;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    [ContextMenu("Spawn")]
    private void DoSpawn()
    {
        List<ItemInfo> spawns = spawner.GetSpawns(totems);

        foreach (var item in spawns)
        {
            OnSpawn?.Invoke(item);
        }
    }
}
