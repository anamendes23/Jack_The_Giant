﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] clouds;

    //distance on the y-axis
    private float distanceBetweenClouds = 3f;
    //keep clouds inside camera
    private float minX, maxX;
    //it will be the trigger for the spawner to create more clouds
    private float lastCloudPositionY;
    //randomize x cloud position, but making sure the player can jump on them
    private float controlX;

    [SerializeField]
    private GameObject[] collectables;
    //used to make sure there's a cloud underneath the player
    //once the game starts
    private GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        controlX = 0;
        SetMinAndMaxX();
        CreateClouds();
        player = GameObject.Find("Player");
    }

    private void Start()
    {
        PositionThePlayer();
    }

    void SetMinAndMaxX()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;
    }

    void Shuffle(GameObject[] arrayToShuffle)
    {
        GameObject temp;
        int random;

        for (int i = 0; i < arrayToShuffle.Length; i++)
        {
            temp = arrayToShuffle[i];
            random = Random.Range(i, arrayToShuffle.Length -1);
            arrayToShuffle[i] = arrayToShuffle[random];
            arrayToShuffle[random] = temp;
        }
    }

    void CreateClouds()
    {
        Shuffle(clouds);
        //for first cloud
        float positionY = 0f;

        for (int i = 0; i < clouds.Length; i++)
        {
            Vector3 temp = clouds[i].transform.position;

            temp.y = positionY;
            
            //creates a zig zag of clouds
            if(controlX == 0)
            {
                temp.x = Random.Range(0.0f, maxX);
                controlX = 1;
            }
            else if(controlX == 1)
            {
                temp.x = Random.Range(0.0f, minX);
                controlX = 2;
            }
            else if (controlX == 2)
            {
                temp.x = Random.Range(1.0f, maxX);
                controlX = 3;
            }
            else if (controlX == 3)
            {
                temp.x = Random.Range(-1.0f, minX);
                controlX = 0;
            }

            lastCloudPositionY = positionY;
            clouds[i].transform.position = temp;
            //update positionY
            positionY -= distanceBetweenClouds;
        }        
    }

    void PositionThePlayer()
    {
        //get references to clouds spawned
        GameObject[] darkClouds = GameObject.FindGameObjectsWithTag("Deadly");
        GameObject[] cloudsInGame = GameObject.FindGameObjectsWithTag("Cloud");
        int tempIndex = 0;
        for (int i = 0; i < darkClouds.Length; i++)
        {
            //swap dark cloud with regular cloud
            if (darkClouds[i].transform.position.y == 0.0f)
            {
                Vector3 t = darkClouds[i].transform.position;
                darkClouds[i].transform.position = new Vector3(
                    cloudsInGame[tempIndex].transform.position.x,
                    cloudsInGame[tempIndex].transform.position.y,
                    cloudsInGame[tempIndex].transform.position.z
                    );

                cloudsInGame[tempIndex].transform.position = t;

                tempIndex++;
            }
        }

        //position player on first cloud
        Vector3 temp = cloudsInGame[0].transform.position;

        for (int i = 0; i < cloudsInGame.Length; i++)
        {
            //check if first cloud is actually first
            if (temp.y < cloudsInGame[i].transform.position.y)
            {
                temp = cloudsInGame[i].transform.position;
            }
        }
        temp.y += 0.8f;
        player.transform.position = temp;
    }
} //Cloud spawner
