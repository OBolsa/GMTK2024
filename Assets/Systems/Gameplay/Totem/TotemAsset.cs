using System.Collections.Generic;
using UnityEngine;

public class TotemAsset : MonoBehaviour
{
    public List<TotemAssetPart> parts = new List<TotemAssetPart>();

    public void SetupPart(TotemItemType type, List<BuffType> buffs)
    {
        TotemAssetPart part = parts.Find(part => part.partType == type);

        part.blue.gameObject.SetActive(buffs.Contains(BuffType.Blue));
        part.red.gameObject.SetActive(buffs.Contains(BuffType.Red));
        part.yellow.gameObject.SetActive(buffs.Contains(BuffType.Yellow));
    }
}

[System.Serializable]
public class TotemAssetPart
{
    public TotemItemType partType;
    public Transform blue;
    public Transform red;
    public Transform yellow;
}