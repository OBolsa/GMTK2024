using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manege : MonoBehaviour
{
    public GameObject PanelPause;
    public bool inPause;

    void Start()
    {
       inPause = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))Pause();
    }

    public void NextScene (string NomeScene)
    {
        SceneManager.LoadScene(NomeScene);
    }

    public void Pause()
    {
        inPause = !inPause;

        PanelPause.SetActive(inPause);
        
    }
}
