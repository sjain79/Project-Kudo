using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject[] platformPrefabs;

    [SerializeField]
    float screenWidth;

    [SerializeField]
    float spawnMinY, spawnMaxY;

    [SerializeField]
    int maxNumberOfPlatforms;

    public static int numberOfPlatforms = 0;

    [SerializeField]
    float lastPlatformY = -3.08f;

    int maxTypeOfPlatform = 8;

    static int score;

    Vector2 startPosition;

    GameObject player;

    private void Start()
    {
        for (int i = numberOfPlatforms; i < maxNumberOfPlatforms; ++i)
        {
            SpawnPlatform();
        }

        player = GameObject.FindGameObjectWithTag("Player");
        startPosition = player.transform.position;

    }

    private void Update()
    {
        if (numberOfPlatforms < maxNumberOfPlatforms)
        {
            SpawnPlatform();
        }

        score = (int)(player.transform.position.y - startPosition.y);
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




}
