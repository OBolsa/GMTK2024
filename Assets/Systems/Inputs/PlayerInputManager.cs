using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public static PlayerInputs Inputs { get; private set; }

    private void Awake()
    {
        Inputs = new PlayerInputs();
        Inputs.Enable();
    }
}