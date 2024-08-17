using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableSquare : MonoBehaviour , IInteractable
{
    private Image lifeGauge;
    
    [SerializeField]
    private float maxHealth;
    private float currentHealth;

    [SerializeField]
    private ItemInfo itemToGive;

    private void Start()
    {
        currentHealth = maxHealth;
        lifeGauge = transform.Find("WorldCanvas").Find("LifeGauge").GetComponent<Image>();
    }


    public void Interact()
    {
        TakeHit();
    }


    private void TakeHit() 
    {
        if(currentHealth > 0) 
        {
            currentHealth -= 1;
            lifeGauge.fillAmount =  (float) (currentHealth / maxHealth);
            Debug.Log("Interacting, currentLife:" + currentHealth);

            if (currentHealth <= 0) Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject, 0.5f);
        PlayerInventory.instance.AddItemToInventory(itemToGive);
    }

}
