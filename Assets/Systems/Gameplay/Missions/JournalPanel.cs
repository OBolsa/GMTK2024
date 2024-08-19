using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JournalPanel : MonoBehaviour
{
    private TextMeshProUGUI missionLabel;
    private TextMeshProUGUI missionTimer;
    private List<TextMeshProUGUI> missionGoals;

    private Transform missionGoalsHolder;
    public GameObject goalLabelPreFab;

    private Image timerImage;

    internal float missionTime = 0;


    private void Start()
    {
        missionLabel = transform.Find("MissionLabelTMP").GetComponent<TextMeshProUGUI>();
        missionTimer = transform.Find("MissionTimerTMP").GetComponent<TextMeshProUGUI>();
        timerImage = transform.Find("Timer Image").Find("Sundial").GetComponent<Image>();
        missionGoalsHolder = transform.Find("MissionGoals");
        missionGoals = new List<TextMeshProUGUI>();
    }

    public void SetCurrentMission(MissionInfo mission)
    {
        missionLabel.text = mission.missionLabel;


        foreach (string goal in mission.missionGoals)
        {
            TextMeshProUGUI goalText = Instantiate(goalLabelPreFab, missionGoalsHolder).GetComponent<TextMeshProUGUI>();
            goalText.text = goal;

        }

        // missionTime = mission.missionTime;

    }




    public void UpdateTimer(float time)
    {
        missionTimer.text = time.ToString("F1");
        timerImage.fillAmount = time / missionTime;
    }

}
