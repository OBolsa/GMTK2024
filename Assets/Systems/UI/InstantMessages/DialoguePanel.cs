using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialoguePanel : MonoBehaviour
{
    public static DialoguePanel instance;
    
    TMP_Text dialogueTMP;


    private void Start()
    {
        if (instance == null) instance = this;
        dialogueTMP = transform.Find("DialogueTMP").GetComponent<TMP_Text>();
        this.gameObject.SetActive(false);
        
    }


    public void ShowMessage(string text) 
    {

        StartCoroutine(WriteMessage(text));
    
    
    }


    IEnumerator WriteMessage(string text) 
    {
     

        dialogueTMP.text = "    ";
        foreach(char c in text.ToCharArray()) 
        {
            dialogueTMP.text += c;
        
            yield return new WaitForSeconds(0.2f);
            
        }


            yield return new WaitForSeconds(1f);

        this.gameObject.SetActive(false);
            
    
    }


}



