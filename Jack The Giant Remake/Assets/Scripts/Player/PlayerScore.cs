using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    private AudioClip coinClip, lifeClip;

    private CameraScript cameraScript;
    private bool countScore;
    private Vector3 previousPosition;

    public static int scoreCount;
    public static int lifeScore;
    public static int coinScore;

    private void Awake()
    {
        cameraScript = Camera.main.GetComponent<CameraScript>();
    }
    // Start is called before the first frame update
    void Start()
    {
        previousPosition = transform.position;
        countScore = true;
    }

    // Update is called once per frame
    void Update()
    {
        CountScore();
    }

    void CountScore()
    {
        if(countScore)
        {
            if(transform.position.y < previousPosition.y)
            {
                scoreCount++;
                previousPosition = transform.position;
            }
            GamePlayController.instance.SetScore(scoreCount);
        }
    }

    //method for when player touch anything
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Coin")
        {
            coinScore++;
            scoreCount += 200;

            GamePlayController.instance.SetScore(scoreCount);
            GamePlayController.instance.SetCoinScore(coinScore);

            AudioSource.PlayClipAtPoint(coinClip, transform.position);
            collision.gameObject.SetActive(false);
        }
        if(collision.tag == "Life")
        {
            lifeScore++;
            scoreCount += 300;

            GamePlayController.instance.SetScore(scoreCount);
            GamePlayController.instance.SetLifeScore(lifeScore);

            AudioSource.PlayClipAtPoint(lifeClip, transform.position);
            collision.gameObject.SetActive(false);
        }
        if(collision.tag == "Bounds" || collision.tag == "Deadly")
        {
            cameraScript.moveCamera = false;
            countScore = false;

            //move player outside of the camera
            transform.position = new Vector3(500, 500, 0);
            lifeScore--;

            GameManager.instance.CheckGameStatus(scoreCount, coinScore, lifeScore);
        }
    }
}
