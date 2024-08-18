using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    // Start is called before the first frame update
    //public int totalQuantityItems;

    public static InventoryUI instance;

    public List<ItemInfo> allItems;
    public List<ItemLabel> allItemsLabel;

    public GameObject itemIcon;

    Transform itemsHolder;

    void Start()
    {
        if (instance == null) instance = this;
        allItems = new List<ItemInfo>();
        itemsHolder = transform.Find("Items");
    }

    
     
    public  void AddItem(ItemInfo Item)
    {
        allItems.Add(Item);
        ItemLabel newItem = Instantiate(itemIcon,itemsHolder).GetComponent<ItemLabel>();
        newItem.SetSprite(Item.itemSprite);
        allItemsLabel.Add(newItem);

    } 

    public void CleanInventory(ItemInfo Item)
    {
        Transform[] items = itemsHolder.GetComponentsInChildren<Transform>();

        foreach (Transform item in items) 
        {
            Destroy(item.gameObject);
        }
        
    }




}
