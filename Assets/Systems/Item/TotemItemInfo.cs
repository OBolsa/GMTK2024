using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TotemItemInfo
{
    public string totemItemName;
    public List<BuffType> totemItemBuffs;
    public Sprite totemItemSprite;

    public TotemItemInfo(string totemItemName, List<BuffType> totemItemBuffs, Sprite totemItemSprite)
    {
        this.totemItemName = totemItemName;
        this.totemItemBuffs = totemItemBuffs;
        this.totemItemSprite = totemItemSprite;
    }
}
