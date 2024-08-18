using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public LevelSpawner level;
    public LevelTimer timer;
    public GameBalanceAttributes balance;
    public int totems;
    public List<SpawnArea> areas = new List<SpawnArea>();
    public List<WorkBench> workBench = new List<WorkBench>();
    private ResourceGroup[] itemGroups;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        itemGroups = new ResourceGroup[3];

        itemGroups[0] = Resources.Load<ResourceGroup>("Resources Groups/Madeira");
        itemGroups[1] = Resources.Load<ResourceGroup>("Resources Groups/Pedra");
        itemGroups[2] = Resources.Load<ResourceGroup>("Resources Groups/Grama");

        areas = FindObjectsOfType<SpawnArea>().ToList();
        workBench = FindObjectsOfType<WorkBench>().ToList();
    }

    private void Start()
    {
        PopulateItems();
        timer.StartCount(level.configs[totems].buildTimerInSeconds);
    }

    public void PlaceTotem()
    {
        totems++;
        workBench.ForEach(bench => bench.RestartBench());
        PopulateItems();
        timer.StartCount(level.configs[totems].buildTimerInSeconds);
    }

    [ContextMenu("Populate")]
    public void PopulateItems()
    {
        areas.ForEach(area => area.SetSpawnTransformersActive(false));

        SpawnConfig configs = level.configs[totems];

        int itemsToSpawnAmount = configs.spawnAmountPerResource;
        bool spawnBuffItemsConfig = configs.spawnItemsWithBuff;

        List<ItemInfo> itemsToSpawn = new List<ItemInfo>();

        for (int i = 0; i < itemGroups.Length; i++)
        {
            List<ItemInfo> spawnItems = GetItemsToSpawn(itemGroups[i], itemsToSpawnAmount, spawnBuffItemsConfig);

            foreach (ItemInfo item in spawnItems)
            {
                itemsToSpawn.Add(item);
            }
        }

        while (itemsToSpawn.Count > 0)
        {
            SpawnArea area = GetRandomAreaItem(itemsToSpawn[0]);

            if (area == null) break;

            area.SpawnItem();
            itemsToSpawn.Remove(itemsToSpawn[0]);
        }
    }

    private List<ItemInfo> GetItemsToSpawn(ResourceGroup group, int amount, bool spawnItemsWithBuff)
    {
        List<ItemInfo> results = new List<ItemInfo>();

        if (spawnItemsWithBuff)
        {
            for (int i = 0; i < amount; i++)
            {
                results.Add(group.GetRandomItem());
            }
        }
        else
        {
            for (int i = 0; i < amount; i++)
            {
                results.Add(group.items[0]);
            }
        }

        return results;
    }

    private SpawnArea GetRandomAreaItem(ItemInfo item)
    {
        List<SpawnArea> results = areas.Where(area => area.spawnItem == item).ToList();

        if (results.Count == 0)
            return null;

        return GetRandomArea(results);
    }

    private SpawnArea GetRandomArea(List<SpawnArea> list)
    {
        if (list.Count == 0)
            return null;

        return list[UnityEngine.Random.Range(0, list.Count)];
    }
}

public class SpawnInfo
{
    public ItemInfo item;
    public Color type;
}
