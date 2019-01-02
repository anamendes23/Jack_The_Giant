using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;

    [SerializeField]
    private Text scoreText, coinText, lifeText, gameOverScoreText, gameOverCoinText;
    [SerializeField]
    private GameObject pausePanel, gameOverPanel;
    [SerializeField]
    private GameObject readyButton;

    // Start is called before the first frame update
    void Awake()
    {
        MakeInstance();
    }

    private void Start()
    {
        Time.timeScale = 0f;
        //get reference to Ready Button

    }

    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void GameOverShowPanel(int finalScore, int finalCoinScore)
    {
        gameOverPanel.SetActive(true);
        gameOverScoreText.text = finalScore.ToString();
        gameOverCoinText.text = "x" + finalCoinScore;

        StartCoroutine(GameOverLoadMainMenu());
    }

    //coroutine
    IEnumerator GameOverLoadMainMenu()
    {
        yield return new WaitForSeconds(4f);
        //SceneManager.LoadScene("MainMenu");
        SceneFader.instance.LoadLevel("MainMenu");
    }

    public void PlayerDiedRestartGame()
    {
        StartCoroutine(PlayerDiedRestart());
    }

    IEnumerator PlayerDiedRestart()
    {
        yield return new WaitForSeconds(4f);
        //SceneManager.LoadScene("GamePlay");
        SceneFader.instance.LoadLevel("GamePlay");
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
        //SceneManager.LoadScene("MainMenu");
        SceneFader.instance.LoadLevel("MainMenu");
    }

    public void StartTheGame()
    {
        Time.timeScale = 1f;
        readyButton.SetActive(false);
    }
}
