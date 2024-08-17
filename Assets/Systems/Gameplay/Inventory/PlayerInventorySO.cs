using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Inventory")]
public class PlayerInventorySO : ScriptableObject
{
    public List<ItemInfo> itemInventory;

    public void AddItemToInventory(ItemInfo item)
    {
        itemInventory.Add(item);
    }

    public void RemoveItemFromInventory(ItemInfo item)
    {
        if (itemInventory.Contains(item)) itemInventory.Remove(item);
    }

    public void RemoveItensFromInventory(ItemInfo[] items)
    {
        for (int i = 0; i < itemInventory.Count; i++)
        {
            if (!itemInventory.Contains(items[i])) return;
            itemInventory.Remove(items[i]);
        }
    }

    public ItemInfo[] GetAllInventoryItems()
    {
        ItemInfo[] items = new ItemInfo[0];

        for (int i = 0; i < itemInventory.Count; i++)
        {
            items[i] = itemInventory[i];

        }

        return items;
    }
}