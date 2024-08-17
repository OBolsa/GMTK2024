using UnityEngine;

public class ResourceSpot : MonoBehaviour
{
    public SpriteRenderer sr;
    public DestroyableObject destroyableConfigs;
    private ItemInfo resourceItem;

    public void SetSpot(ItemInfo item)
    {
        resourceItem = item;
        sr.sprite = resourceItem.itemSprite;
        destroyableConfigs.SetupDestroyable(resourceItem.itemLife, resourceItem.itemLife);
    }

    public void GiveItemToPlayer(PlayerInventorySO inventory)
    {
        inventory.AddItemToInventory(resourceItem);
    }
}
