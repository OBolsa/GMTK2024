using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventario : MonoBehaviour
{
    // Start is called before the first frame update
    //public int totalQuantityItems;
    
    public GameObject iconMaterial;
    public GameObject listaMateriais;
    public List<ItemInfo> allItems;
    void Start()
    {
        allItems = new List<ItemInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     
    public  void addMaterial_UI (ItemInfo Item)
    {
      
               GameObject newItem = Instantiate(iconMaterial, this.transform.position, Quaternion.identity);
               newItem.transform.parent = listaMateriais.transform;
               newItem.GetComponent<Image>().sprite = Item.itemSprite;
               newItem.transform.SetSiblingIndex(0);
               newItem.name = Item.itemName;
               allItems.Add(Item);

    } 

    public void removeMaterial_UI (ItemInfo Item)
    {


        
    }


    public void removeMaterialInHand_UI()
    {
        
    }


}
