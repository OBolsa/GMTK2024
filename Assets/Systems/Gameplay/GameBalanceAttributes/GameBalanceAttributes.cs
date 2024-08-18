using UnityEngine;

[CreateAssetMenu(menuName = "SO/Balance")]
public class GameBalanceAttributes : ScriptableObject
{
    [Header("Player Base Attributes")]
    public float playerBaseMovementSpeed;
    public float playerBaseDamage;

    [Header("Resources Base Attributes")]
    public float basicResourceHealth;
    public float buffResourceHealth;

    [Header("Buffs Attributes")]
    public float speedIncreasePerBuff;
    public float damageIncreasePerBuff;
    public float timeIncreasePerBuff;
}
