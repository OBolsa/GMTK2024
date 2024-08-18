using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class InventoryUI : MonoBehaviour
{
    // Start is called before the first frame update
    //public int totalQuantityItems;

    public static InventoryUI instance;
    public List<ItemLabel> allItemsLabel;



    public GameObject itemIcon;

    Transform itemsHolder;

    void Start()
    {
        if (instance == null) instance = this;
        allItemsLabel = new List<ItemLabel>();
        itemsHolder = transform.Find("Items");
    }

    
     
    public  void AddItem(ItemInfo Item)
    {

        ItemLabel newItem = Instantiate(itemIcon,itemsHolder).GetComponent<ItemLabel>();
        newItem.InitializeLabel(Item);
        allItemsLabel.Add(newItem);

    } 

    public void RemoveItem(ItemInfo item) 
    {
        bool hasRemoved = false;

        ItemLabel labelToRemove = allItemsLabel.Find(label => label.GetItemInfo() == item);
        if(labelToRemove != null) 
        {
            labelToRemove.Erase();
            allItemsLabel.Remove(labelToRemove);
        
        }



    }


    public void CleanInventory()
    {
       foreach(ItemLabel label in allItemsLabel) 
       {
            label.Erase();
            allItemsLabel.Remove(label);
            

       }
        
    }




}
