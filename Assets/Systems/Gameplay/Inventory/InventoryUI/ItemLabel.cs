using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemLabel : MonoBehaviour
{
    private Image itemSprite;

    private void Start()
    {
    }
    public void SetSprite(Sprite sprite) 
    {
        itemSprite = transform.Find("ItemSprite").GetComponent<Image>();
        itemSprite.sprite = sprite;
    }
}
