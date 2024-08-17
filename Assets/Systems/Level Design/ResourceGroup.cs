using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Resource Type")]
public class ResourceGroup : ScriptableObject
{
    public string type;
    public Color baseColor;
    public List<ItemInfo> items;

    public ItemInfo GetRandomItem() => items[Random.Range(0, items.Count)];
}