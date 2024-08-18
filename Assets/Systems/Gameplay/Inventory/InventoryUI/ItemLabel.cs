using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemLabel : MonoBehaviour
{
    private Image itemSprite;
    private ItemInfo item;


    public void InitializeLabel(ItemInfo itemInfo)
    {
        item = itemInfo;
        SetSprite(item.itemSprite);
    }
    public void SetSprite(Sprite sprite) 
    {
        itemSprite = transform.Find("ItemSprite").GetComponent<Image>();
        itemSprite.sprite = sprite;
    }

    public ItemInfo GetItemInfo() 
    {
        return item;
    }
    public void Erase() 
    {
        Destroy(this.gameObject);
    
    }

}
