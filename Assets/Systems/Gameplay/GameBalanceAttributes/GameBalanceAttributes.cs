using System.Collections.Generic;
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

    private float playerDamage;

    [Header("Current Attributes")]
    public float totalSpeed;
    public float totalDamage;
    public float totalExtraTime;

    public void UpdateBuffs(List<BuffType> buffs)
    {
        totalExtraTime = 0;
        totalDamage = playerBaseDamage;
        totalSpeed = playerBaseMovementSpeed;

        foreach (var buff in buffs)
        {
            if (buff == BuffType.Yellow)
            {
                totalExtraTime += timeIncreasePerBuff;
            }
            else if (buff == BuffType.Red)
            {
                totalDamage += damageIncreasePerBuff;
            }
            else if (buff == BuffType.Blue)
            {
                totalSpeed += speedIncreasePerBuff;
            }
        }
    }

    public float GetPlayerDamage() => totalDamage;
    public float SetPlayerDamage(float newDamage) => playerDamage = newDamage;

}
