using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private Rigidbody2D rb;

    private Vector2 desiredDirection;

    private string movementDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        desiredDirection = PlayerInputManager.Inputs.World.Movement.ReadValue<Vector2>();

        if (desiredDirection.magnitude > 0.1f)
        {
            PlayerAnimation.instance.PlayWalkAnimation(desiredDirection);
            rb.velocity = desiredDirection.normalized * movementSpeed;
        }
        else
        {
            PlayerAnimation.instance.GoIntoIdle();
            rb.velocity = Vector2.zero;
        }
    }

}

