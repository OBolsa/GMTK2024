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
    
 
    public List<ItemInfo> allItems;
    public GameObject itemIcon;

    Transform itemsHolder;

    void Start()
    {
        allItems = new List<ItemInfo>();
        itemsHolder = transform.Find("ItemsList");
    }

    
     
    public  void AddItem(ItemInfo Item)
    {
        GameObject newItem = Instantiate(itemIcon, this.transform.position, Quaternion.identity, itemsHolder);       
        newItem.transform.Find("ItemSprite").GetComponent<Image>().sprite = Item.itemSprite;
        allItems.Add(Item);

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
