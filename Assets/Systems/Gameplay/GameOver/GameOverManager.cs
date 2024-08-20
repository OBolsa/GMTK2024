using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        Time.timeScale = 1;
        SceneManager.LoadScene("Level 1");

    }

}
