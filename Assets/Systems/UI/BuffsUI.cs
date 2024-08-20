using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class BuffsUI : MonoBehaviour
{
    public TMP_Text display;
    public BuffType type;
    private int amount;

    private void OnEnable()
    {
        LevelManager.Instance.LevelStarted += UpdateValues;
    }

    private void OnDisable()
    {
        LevelManager.Instance.LevelStarted -= UpdateValues;
    }

    private void UpdateValues(int level)
    {
        List<BuffType> buffs = LevelManager.Instance.buffs;

        amount = buffs.Where(b => b == type).Count();
        display.text = amount.ToString();
    }
}