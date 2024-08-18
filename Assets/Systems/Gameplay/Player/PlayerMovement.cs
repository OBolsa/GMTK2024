using System.Collections.Generic;
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
        LevelManager.Instance.TotemPartDone += MovementBuffsUpdate;
    }

    private void OnDisable()
    {
        LevelManager.Instance.TotemPartDone -= MovementBuffsUpdate;
    }

    private void Start()
    {
        movementSpeed = attributes.playerBaseMovementSpeed;
    }

    private void Update()
    {
        Move();
    }

    private void MovementBuffsUpdate(TotemItemInfo totemInfo)
    {
        List<BuffType> totemBuffs = new List<BuffType>(totemInfo.totemItemBuffs);

        foreach (var buff in totemBuffs)
        {
            if (buff == BuffType.Blue)
            {
                movementSpeed += attributes.speedIncreasePerBuff;
            }
        }
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