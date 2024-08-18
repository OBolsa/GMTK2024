using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InstantMessageHandler : MonoBehaviour
{
    public static InstantMessageHandler instance;

    public Transform player;

    public GameObject instantMessagePreFab;

    private void Awake()
    {
        if (instance == null) instance = this;
        player = FindObjectOfType<PlayerMovement>().transform;
    }


    public void ShowMessage(string messageText) 
    {
        float randomYPos= player.position.y + 10 + Random.Range(5, 20);
        float randomXPos = player.position.x + Random.Range(-20, 20);
        Vector3 randomPos = new Vector3(randomXPos,randomYPos,0);
        
        TextMeshProUGUI  instantMessageText = Instantiate(instantMessagePreFab,randomPos,Quaternion.identity).GetComponentInChildren<TextMeshProUGUI>();
        instantMessageText.text = messageText;
        Destroy(instantMessageText.transform.parent.gameObject, 1f);
    
    }


}
