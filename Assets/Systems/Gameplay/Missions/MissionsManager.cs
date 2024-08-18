
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionsManager : MonoBehaviour
{
    public static MissionsManager instance;


    [SerializeField]
    private MissionInfo[] missions;


    private int currentMission = 0;


    private JournalPanel journalPanel;
    private DialoguePanel dialoguePanel;
    
    
    private void Awake()
    {
        if (instance == null) instance = this;
        
    }
    private void Start()
    {

        journalPanel = FindObjectOfType<JournalPanel>();
        dialoguePanel = FindObjectOfType<DialoguePanel>();
        SetCurrentMissionOnJournal();

    }

    public void SetTime(float maxTime) 
    {

        journalPanel.missionTime = maxTime;
    
    }

    private void SetCurrentMissionOnJournal() 
    {
        journalPanel.SetCurrentMission(missions[currentMission]);
        DialoguePanel.instance.gameObject.SetActive(true);
        DialoguePanel.instance.ShowMessage(missions[currentMission].missionLabel);

        
    }

    public void SetNextMission() 
    {
        currentMission += 1;
        if(currentMission <= missions.Length) SetCurrentMissionOnJournal();
    }


    public void UpdateTimerOnUI(float currentTime) 
    {
        journalPanel.UpdateTimer(currentTime);
    }
    public void GameOver() 
    {
        Debug.Log("GAME OVER!!!!");
       // Time.timeScale = 0.5f;
        
    }
}
