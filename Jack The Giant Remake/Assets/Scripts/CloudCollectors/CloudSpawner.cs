using System.Collections;
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
        Vector3 temp;

        for (int i = 0; i < clouds.Length; i++)
        {
            temp = clouds[i].transform.position;

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
} //Cloud spawner
