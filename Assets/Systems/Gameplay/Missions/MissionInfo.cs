using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "SO/Mission")]
public class MissionInfo : ScriptableObject
{

    [TextArea]
    public string missionLabel;

    [TextArea]
    public string[] missionGoals;

    public float missionTime;
    
}
