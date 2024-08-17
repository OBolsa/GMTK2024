using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Resource Type")]
public class ResourceType : ScriptableObject
{
    public string type;
    public string buff;
    public List<ItemInfo> items;

    public ItemInfo GetRandomItem() => items[Random.Range(0, items.Count)];
}