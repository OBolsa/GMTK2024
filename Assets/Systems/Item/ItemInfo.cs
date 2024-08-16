using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Item")]
public class ItemInfo : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite itemSprite;
    public List<ItemInfo> itemRequirements;

    public bool HaveRequisitions(List<ItemInfo> items)
    {
        List<ItemInfo> itemsInBag = new List<ItemInfo>(items);

        for (int i = 0; i < itemRequirements.Count; i++)
        {
            if (itemsInBag.Contains(itemRequirements[i]))
            {
                itemsInBag.Remove(itemRequirements[i]);
            }
            else
            {
                return false;
            }
        }

        return true;
    }
}
