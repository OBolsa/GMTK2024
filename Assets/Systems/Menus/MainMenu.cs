using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button _playButton;
    public Button _creditsButton;
    public Button _closeCredits;


    public GameObject credits;

    private void Start()
    {

      
        _playButton.onClick.AddListener(() => { PlayButton(); });
        _creditsButton.onClick.AddListener(() => { CreditsPanel(true); });
        _closeCredits.onClick.AddListener(() => { CreditsPanel(false); });


        CreditsPanel(false);
    
    }

    void PlayButton() 
    {

        SceneManager.LoadScene("Level1");
    
    }


    void CreditsPanel(bool onOff)
    {

        credits.SetActive(onOff);
        _playButton.gameObject.SetActive(!onOff);
        _creditsButton.gameObject.SetActive(!onOff);



    }
}
