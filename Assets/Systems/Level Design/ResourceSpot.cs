using UnityEngine;

public class ResourceSpot : MonoBehaviour
{
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void SetSpot(ItemInfo item)
    {
        sr.sprite = item.itemSprite;
    }
}
