using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private Button musicButton;
    [SerializeField]
    private Sprite[] musicIcons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void CheckToPlayMusic()
    {
        if(GamePreferences.GetMusicState() == 1)
        {
            MusicController.instance.PlayMusic(true);
            musicButton.image.sprite = musicIcons[1];
        }
        else
        {
            MusicController.instance.PlayMusic(false);
            musicButton.image.sprite = musicIcons[0];
        }
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
        if(GamePreferences.GetMusicState()==0)
        {
            GamePreferences.SetMusicState(1);
            CheckToPlayMusic();
        }
        else if(GamePreferences.GetMusicState() == 1)
        {
            GamePreferences.SetMusicState(0);
            CheckToPlayMusic();
        }
    }
}
