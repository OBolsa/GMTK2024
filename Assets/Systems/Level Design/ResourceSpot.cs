using UnityEngine;

public class ResourceSpot : MonoBehaviour
{
    private SpriteRenderer sr;
    private DestroyableObject destroyableConfigs;
    private ItemInfo resourceItem;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        destroyableConfigs = GetComponent<DestroyableObject>();
    }

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
