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
    public ItemInfo [] allItems;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     
    public  void addMaterialUI (String nomeItem)
    {
          foreach (ItemInfo item in allItems)
        {
            if (item.itemName == nomeItem)
            {
               GameObject newItem = Instantiate(iconMaterial, this.transform.position, Quaternion.identity);
               newItem.transform.parent = listaMateriais.transform;
               newItem.GetComponent<Image>().sprite = item.itemSprite;
               newItem.name = nomeItem;
               break;
            }
        }

    } 

    public void removeMaterialUI (String nomeItem)
    {
        Transform childTransform = listaMateriais.transform.Find(nomeItem);

        Destroy(childTransform.gameObject);
    }




}
