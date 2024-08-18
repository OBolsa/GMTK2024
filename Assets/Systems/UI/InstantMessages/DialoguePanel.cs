using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialoguePanel : MonoBehaviour
{

    
    TMP_Text dialogueTMP;


    private void Awake()
    {
        dialogueTMP = transform.Find("DialogueTMP").GetComponent<TMP_Text>();
        dialogueTMP.gameObject.SetActive(false);
        
    }


    public void ShowMessage(string text) 
    {

        StartCoroutine(WriteMessage(text));
    
    
    }


    IEnumerator WriteMessage(string text) 
    {
        dialogueTMP.gameObject.SetActive(true);

        dialogueTMP.text = "    ";
        foreach(char c in text.ToCharArray()) 
        {
            dialogueTMP.text += c;
        
            yield return new WaitForSeconds(0.2f);
            
        }


            yield return new WaitForSeconds(1f);

        dialogueTMP.gameObject.SetActive(false);
            
    
    }


}



