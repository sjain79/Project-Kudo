using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject[] platformPrefabs;

    [SerializeField]
    GameObject cloudPrefab, wingMan, coin, bubble, rocket;

    [SerializeField]
    float screenWidth;

    [SerializeField]
    float spawnMinY, spawnMaxY;

    [SerializeField]
    int maxNumberOfPlatforms;

    public static int numberOfPlatforms = 0;

    [SerializeField]
    float lastPlatformY = -3.08f;

    int maxTypeOfPlatform = 9;

    static float score;

    Vector2 startPosition;

    GameObject player;

    float previousScore = 0;

    private void Start()
    {
        for (int i = numberOfPlatforms; i < maxNumberOfPlatforms; ++i)
        {
            SpawnPlatform();
        }

        player = GameObject.FindGameObjectWithTag("Player");
        startPosition = player.transform.position;

        InvokeRepeating("SpawnCoins", 1.5f, 1.5f);
    }

    private void Update()
    {
        if (numberOfPlatforms < maxNumberOfPlatforms)
        {
            SpawnPlatform();
        }

        if (score < (player.transform.position.y - startPosition.y) * 10)
        {
            score = (player.transform.position.y - startPosition.y);
            score *= 10;
        }
        //Debug.Log("Score " + (int)score);


        if (score >= previousScore + 20)
        {
            //Instantiate(cloudPrefab, new Vector2(Random.Range(-screenWidth, screenWidth), player.transform.position.y + 2f), Quaternion.identity);
            previousScore = score;
        }

    }

    private void SpawnPlatform()
    {
        int platformType = 0;

        switch (Random.Range(0, maxTypeOfPlatform))
        {
            case 0:
            case 1:
            case 2:
                platformType = 0;
                break;
            case 3:
            case 4:
                platformType = 1;
                break;
            case 5:
            case 6:
                platformType = 2;
                break;
            case 7:
                platformType = 3;
                break;
            case 8:
                platformType = 4;
                break;

        }

        Instantiate(platformPrefabs[platformType], new Vector2(Random.Range(-screenWidth, screenWidth), lastPlatformY += Random.Range(spawnMinY, spawnMaxY)), Quaternion.identity);
        numberOfPlatforms++;
    }


    private void SpawnCoins()
    {
        Instantiate(coin, new Vector2(Random.Range(-screenWidth, screenWidth), lastPlatformY + 2), Quaternion.identity);
    }

    private void SpawnWorld ()
    {
        int itemType=0;
        switch (Random.Range(0,20))
        {
            case 0:
            case 1:
            case 2: itemType = 0; //normalplatform
                break;
            case 3:
            case 4:
            case 5: itemType = 1; //platform with a bush
                break;
            case 6:
            case 7:
            case 8: itemType = 2; //breakable platform
                break;
            case 9:
            case 10: itemType = 3;//platform with spring
                break;
            case 11:
            case 12: itemType = 4; //platform with enemy
                break;
            case 13:
                itemType = 5; //cloud enemy
                break;
            case 14: itemType = 6; //Wing man enemy
                break;
            case 15: itemType = 7; //rocket power up;
                break;
            case 16:
            case 17: itemType = 8; //bubble power up
                break;

        }

        Instantiate(platformPrefabs[itemType], new Vector2(Random.Range(-screenWidth, screenWidth), lastPlatformY += Random.Range(spawnMinY, spawnMaxY)), Quaternion.identity);
    }

}
