using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    public ItemInfo spawnItem;
    private List<ResourceSpot> areaDelimiters = new List<ResourceSpot>();

    private void Awake()
    {
        areaDelimiters = GetComponentsInChildren<ResourceSpot>(true).ToList();
    }

    public void SetSpawnTransformersActive(bool active)
    {
        areaDelimiters.ForEach(area => area.gameObject.SetActive(active));
    }

    public void SpawnItem()
    {
        ResourceSpot spot = GetSpawnTransform();
        spot.SetSpot(spawnItem);
        spot.gameObject.SetActive(true);
    }

    private ResourceSpot GetSpawnTransform()
    {
        List<ResourceSpot> possiblePositions = areaDelimiters.Where(point => !point.gameObject.activeSelf).ToList();

        int random = Random.Range(0, possiblePositions.Count);
        return possiblePositions[random];
    }

    private void OnValidate()
    {
        string name = "Spawn Area";
        if (spawnItem != null) name += $" - {spawnItem.itemName}";

        this.name = name;
    }
}
