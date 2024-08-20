using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button _playButton;
    public Button _creditsButton;
    public Button _closeCredits;
    public Button _exitGame;


    public GameObject credits;

    private void Start()
    {


        _playButton.onClick.AddListener(() => { PlayButton(); });
        _creditsButton.onClick.AddListener(() => { CreditsPanel(true); });
        _closeCredits.onClick.AddListener(() => { CreditsPanel(false); });
        _exitGame.onClick.AddListener(() => { QuitGame(); });


        CreditsPanel(false);

    }

    void PlayButton()
    {

        SceneManager.LoadScene("Level 1");

    }


    void CreditsPanel(bool onOff)
    {

        credits.SetActive(onOff);
        _playButton.gameObject.SetActive(!onOff);
        _creditsButton.gameObject.SetActive(!onOff);



    }

    void QuitGame()
    {
        Application.Quit();
    }
}
