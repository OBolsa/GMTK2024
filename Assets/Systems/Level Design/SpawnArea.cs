using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    public ItemInfo itemToSpawn;
    public List<Transform> areaDelimiters = new List<Transform>();

    private void OnEnable()
    {
        LevelManager.Instance.OnSpawn += SpawnItem;
    }

    private void OnDisable()
    {
        LevelManager.Instance.OnSpawn -= SpawnItem;
    }

    private void SpawnItem(ItemInfo item)
    {
        foreach (Transform t in areaDelimiters)
        {
            t.gameObject.SetActive(false);
        }

        Transform spawn = GetSpawn();
        spawn.gameObject.SetActive(true);
    }

    private Transform GetSpawn()
    {
        List<Transform> possiblePositions = areaDelimiters.Where(point => !point.gameObject.activeSelf).ToList();

        int random = Random.Range(0, possiblePositions.Count);
        return possiblePositions[random];
    }
}
