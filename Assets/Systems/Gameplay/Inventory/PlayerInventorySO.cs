using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Inventory")]
public class PlayerInventorySO : ScriptableObject
{
    public List<ItemInfo> itemInventory;
    public List<TotemItemInfo> totemInventory = new List<TotemItemInfo>();

    private void OnEnable()
    {
        itemInventory.Clear();
        totemInventory.Clear();
    }

    public void CleanTotemItemInfoList()
    {
        totemInventory.Clear();
    }

    public bool HaveItem(ItemInfo item) => itemInventory.Contains(item);
    public bool HaveAnyItemsOfItemGroup(ResourceGroup group)
    {
        List<ItemInfo> itemsInGroup = new List<ItemInfo>(group.items);

        return itemsInGroup.Any(itemsInGroup => itemInventory.Contains(itemsInGroup));
    }

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

    public ItemInfo FindFirstMatchingItem(List<ItemInfo> listA, List<ItemInfo> listB)
    {
        return listA.FirstOrDefault(itemA => listB.Contains(itemA));
    }
}