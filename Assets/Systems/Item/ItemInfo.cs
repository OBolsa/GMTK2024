using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Item")]
public class ItemInfo : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite itemSprite;
    public AudioClip itemSfx;
    public List<BuffType> itemBuffs;
    public int itemLife;
}

public enum BuffType { None, Yellow, Red, Blue }