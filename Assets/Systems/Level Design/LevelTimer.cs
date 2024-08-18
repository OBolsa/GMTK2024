using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    public float maxTime;
    private float currentTime;
    private float extraTime;
    bool isCounting;
    MissionsManager mission;


    private void Start()
    {
        mission = MissionsManager.instance;
    }
    private void Update()
    {
        if (isCounting)
        {
            Count();
        }
    }

    private void UpdateExtraTime(TotemItemInfo totemInfo)
    {
        List<BuffType> totemBuffs = new List<BuffType>(totemInfo.totemItemBuffs);

        foreach (var buff in totemBuffs)
        {
            if (buff == BuffType.Yellow)
            {
                extraTime += LevelManager.Instance.attributes.timeIncreasePerBuff;
            }
        }
    }

    public void StartCount(float time)
    {
        maxTime = time;
        MissionsManager.instance.SetTime(maxTime);
        currentTime = maxTime;
        isCounting = true;
    }

    private void Count()
    {
        currentTime -= Time.deltaTime;
        mission.UpdateTimerOnUI(currentTime);


        if (currentTime < 0)
        {
            isCounting = false;
            LevelManager.Instance.Fail();
            InstantMessageHandler.instance.ShowMessage("PERDEU PLAYBOY");
            Debug.Log("PERDEU PLAYBOY");
        }
    }

    private void OnGUI()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(currentTime);
        string timeText = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);

        GUI.Label(new Rect(0, 0, 100, 100), timeText);
    }
}