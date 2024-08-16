using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator playerAnimator;

    public static PlayerAnimation instance;

    private MovementDirection currentLookDirection;

    private void Start()
    {
        if (instance == null) instance = this;
        playerAnimator = GetComponent<Animator>();
    }



    public void PlayWalkAnimation(Vector2 directionVector) 
    {
        currentLookDirection = CalculateDirection(directionVector);
        switch (currentLookDirection)
        {
            case MovementDirection.WEST:
                playerAnimator.Play("WalkAnimW");
                break;
            case MovementDirection.EAST:
                playerAnimator.Play("WalkAnimE");
                break;
            case MovementDirection.NORTH:
                playerAnimator.Play("WalkAnimN");
                break;

            default:
                playerAnimator.Play("WalkAnimS");
                break;

        }
    }

    public void GoIntoIdle()
    {
        switch (currentLookDirection) 
        {
            case MovementDirection.WEST:
                    playerAnimator.Play("IdleAnimW");
                break;
            case MovementDirection.EAST:
                    playerAnimator.Play("IdleAnimE");
                break;
            case MovementDirection.NORTH:
                    playerAnimator.Play("IdleAnimN");
                break;

            default:
                    playerAnimator.Play("IdleAnimS");
                break;
        
        }
    }

    MovementDirection CalculateDirection(Vector2 directionVector) 
    {

        if (directionVector.x == 1) return MovementDirection.EAST;
        else if (directionVector.x == -1) return MovementDirection.WEST;
        else if (directionVector.y == 1) return MovementDirection.NORTH;
        else return MovementDirection.SOUTH;

    }

}

public enum MovementDirection
{
    WEST,
    EAST,
    NORTH,
    SOUTH


}

