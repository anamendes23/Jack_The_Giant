using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame()
    {
        GameManager.instance.gameStartedFromMenu = true;
        GameManager.instance.gameRestartedAfterPlayerDied = false;
        SceneManager.LoadScene("GamePlay");
    }

    public void GoToHighScoreMenu()
    {
        SceneManager.LoadScene("HighScore");
    }

    public void GoToOptionsMenu()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MusicButton()
    {

    }
}
