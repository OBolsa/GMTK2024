using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    private bool stepingOnInteraction;
    IInteractable interactableObject;

    private void OnEnable()
    {
        PlayerInputManager.Inputs.World.Action.performed += DoInteraction;
    }

    private void OnDisable()
    {
        PlayerInputManager.Inputs.World.Action.performed -= DoInteraction;
    }

    private void DoInteraction(InputAction.CallbackContext context)
    {
        if (interactableObject != null)
        {
            interactableObject.Interact();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent(out IInteractable interactableObj))
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
