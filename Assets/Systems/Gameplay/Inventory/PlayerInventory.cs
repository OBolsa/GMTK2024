using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<ItemInfo> itemInventory;


    private void Start()
    {
        itemInventory = new List<ItemInfo>();
    }


    public void AddItemToInventory(ItemInfo item) 
    {
        itemInventory.Add(item);
    }

    public void RemoveItemFromInventory(ItemInfo item)
    {
        if(itemInventory.Contains(item)) itemInventory.Remove(item);
    }

    public void RemoveItensFromInventory(ItemInfo[] items)
    {
        for(int i = 0; i < itemInventory.Count; i++ )
        {
            if (!itemInventory.Contains(items[i])) return;
            itemInventory.Remove(items[i]);
        }

    }


    public ItemInfo[] GetAllInventoryItems() 
    {
        return itemInventory;
    }

}
