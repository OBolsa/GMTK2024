using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSquare : MonoBehaviour , IInteractable
{ 

    public void Interact()
    {
        Debug.Log("Interacting");
    }

}
