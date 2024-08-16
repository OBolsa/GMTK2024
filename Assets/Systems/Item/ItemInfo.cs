using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Item")]
public class ItemInfo : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite itemSprite;
    public List<ItemInfo> itemRequisitions;

    public bool HaveRequisitions(List<ItemInfo> items)
    {
        List<ItemInfo> itemsInBag = new List<ItemInfo>(items);

        for (int i = 0; i < itemRequisitions.Count; i++)
        {
            if (itemsInBag.Contains(itemRequisitions[i]))
            {
                itemsInBag.Remove(itemRequisitions[i]);
            }
            else
            {
                return false;
            }
        }

        return true;
    }
}
