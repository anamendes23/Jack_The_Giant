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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
} //Cloud spawner
