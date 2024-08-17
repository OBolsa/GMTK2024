using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    public void Interact();

}

public class PlayerInteractor : MonoBehaviour
{
    private bool stepingOnInteraction;
    IInteractable interactableObject;

    void Update()
    {

        if (interactableObject != null && PlayerInputManager.Inputs.World.Action.triggered) interactableObject.Interact();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.TryGetComponent(out IInteractable interactableObj)) 
        {
            interactableObject = interactableObj;

        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent(out IInteractable interactableObj))
        {
            interactableObject = null;

        }


    }
}
