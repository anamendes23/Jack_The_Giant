using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector]
    public bool gameStartedFromMenu, gameRestartedAfterPlayerDied;
    [HideInInspector]
    public int score, coinScore, lifeScore;

    // Start is called before the first frame update
    void Awake()
    {
        MakeSingleton();
    }

    private void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().name == "GamePlay")
        {
            if(gameRestartedAfterPlayerDied)
            {
                GamePlayController.instance.SetScore(score);
                GamePlayController.instance.SetCoinScore(coinScore);
                GamePlayController.instance.SetLifeScore(lifeScore);

                PlayerScore.scoreCount = score;
                PlayerScore.coinScore = coinScore;
                PlayerScore.lifeScore = lifeScore;
            }
            else if(gameStartedFromMenu)
            {
                GamePlayController.instance.SetScore(0);
                GamePlayController.instance.SetCoinScore(0);
                GamePlayController.instance.SetLifeScore(2);

                PlayerScore.scoreCount = 0;
                PlayerScore.coinScore = 0;
                PlayerScore.lifeScore = 2;
            }
        }
    }

    void MakeSingleton()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void CheckGameStatus(int score, int coinScore, int lifeScore)
    {
        if(lifeScore < 0)
        {
            //game over
            gameStartedFromMenu = false;
            gameRestartedAfterPlayerDied = false;

            //gameplay controller to reload level
            GamePlayController.instance.GameOverShowPanel(score, coinScore);
        }
        else
        {
            this.score = score;
            this.coinScore = coinScore;
            this.lifeScore = lifeScore;

            gameStartedFromMenu = false;
            gameRestartedAfterPlayerDied = true;

            GamePlayController.instance.PlayerDiedRestartGame();
        }
    }
}
