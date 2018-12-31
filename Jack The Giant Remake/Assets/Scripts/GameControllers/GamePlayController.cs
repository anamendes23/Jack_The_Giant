using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;

    [SerializeField]
    private Text scoreText, coinText, lifeText;
    [SerializeField]
    private GameObject pausePanel;

    // Start is called before the first frame update
    void Awake()
    {
        MakeInstance();
    }

    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void SetCoinScore(int coinScore)
    {
        coinText.text = "x" + coinScore;
    }

    public void SetLifeScore(int lifeScore)
    {
        lifeText.text = "x" + lifeScore;
    }

    public void PauseTheGame()
    {
        //stop the game
        Time.timeScale = 0;
        //show the pause panel
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        //resume the game
        Time.timeScale = 1f;
        //hide the pause panel
        pausePanel.SetActive(false);
    }

    public void QuitGame()
    {
        //resume the game
        Time.timeScale = 1f;
        //go back to main menu
        SceneManager.LoadScene("MainMenu");
    }
}
