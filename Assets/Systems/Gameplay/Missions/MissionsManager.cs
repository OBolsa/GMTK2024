
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionsManager : MonoBehaviour
{
    public static MissionsManager instance;


    [SerializeField]
    private MissionInfo[] missions;


    private int currentMission = 0;
    float timer;

    private JournalPanel journalPanel;

    private void Start()
    {

        journalPanel = FindObjectOfType<JournalPanel>();
        SetCurrentMissionOnJournal();
        if (instance == null) instance = this;

    }



    private void SetCurrentMissionOnJournal() 
    {
        journalPanel.SetCurrentMission(missions[currentMission]);
        timer = missions[currentMission].missionTime;
        StartCoroutine(RunTimer());
    }

    public void SetNextMission() 
    {
        currentMission += 1;
        if(currentMission <= missions.Length) SetCurrentMissionOnJournal();
    }

    IEnumerator RunTimer() 
    {
    
        while(timer > 0) 
        {


            timer -= Time.deltaTime;
            journalPanel.UpdateTimer(timer);
            yield return null;
        }

        GameOver();
    
    
    }

    public void GameOver() 
    {
        Debug.Log("GAME OVER!!!!");
       // Time.timeScale = 0.5f;
        
    }
}
