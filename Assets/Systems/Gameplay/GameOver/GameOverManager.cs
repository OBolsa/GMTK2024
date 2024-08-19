using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance;
    public GameObject gameOverPanel;
    public Button restartButton;

    private void Start()
    {
        if (instance == null) instance = this;
        restartButton.onClick.AddListener(() => { RestartGame(); });
        gameOverPanel.SetActive(false);
    }

    public void GameOver() 
    {

        Time.timeScale = 0.5f;
        gameOverPanel.SetActive(true);    
    }
    
    void RestartGame() 
    {

        SceneManager.LoadScene("Level");
    
    }

}
