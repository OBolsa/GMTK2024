using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameBalanceAttributes attributes;
    private float movementSpeed;
    private Rigidbody2D rb;

    private Vector2 desiredDirection;
    private string movementDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        LevelManager.Instance.TotemPlaced += MovementBuffsUpdate;
    }

    private void OnDisable()
    {
        LevelManager.Instance.TotemPlaced -= MovementBuffsUpdate;
    }

    private void Start()
    {
        movementSpeed = attributes.totalSpeed;
    }

    private void Update()
    {
        Move();
    }

    private void MovementBuffsUpdate()
    {
        movementSpeed = attributes.totalSpeed;
    }

    private void Move()
    {
        desiredDirection = PlayerInputManager.Inputs.World.Movement.ReadValue<Vector2>();

        if (desiredDirection.magnitude > 0.1f)
        {
            PlayerAnimation.instance.PlayWalkAnimation(desiredDirection);
            rb.velocity = desiredDirection.normalized * movementSpeed;
            AudioManager.instance.SetPlayerSteps(true);
        }
        else
        {
            PlayerAnimation.instance.GoIntoIdle();
            AudioManager.instance.SetPlayerSteps(false);
            rb.velocity = Vector2.zero;

        }
    }
}