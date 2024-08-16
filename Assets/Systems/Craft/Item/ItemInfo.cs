using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Item")]
public class ItemInfo : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite itemSprite;
    public List<ItemInfo> itemRequests = new List<ItemInfo>();

    public bool HaveRequisitions(List<ItemInfo> items)
    {
        List<ItemInfo> itemsInBag = new List<ItemInfo>(items);

        for (int i = 0; i < itemRequests.Count; i++)
        {
            if (itemsInBag.Contains(itemRequests[i]))
            {

            }
        }

        return true;
    }
}