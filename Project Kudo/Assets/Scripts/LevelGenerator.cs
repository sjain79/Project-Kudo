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
    
    public static int numberOfPlatforms=0;

    [SerializeField]
    float lastPlatformY= -3.08f;

    int maxTypeOfPlatform = 2;

    private void Start()
    {
        for (int i=numberOfPlatforms;i<maxNumberOfPlatforms;++i)
        {
            SpawnPlatform();
        }
    }

    private void Update()
    {
        if (numberOfPlatforms<maxNumberOfPlatforms)
        {
            SpawnPlatform();
        }
    }

    private void SpawnPlatform()
    {
        int platformType=0;

        switch (Random.Range(0, maxTypeOfPlatform+1))
        {
            case 0:
            case 1:
                platformType = 0;
                break;
            case 2:
                platformType = 1;
                break;
            case 3:
                platformType = 2;
                break;
        }

        Instantiate(platformPrefabs[platformType], new Vector2(Random.Range(-screenWidth, screenWidth), lastPlatformY += Random.Range(spawnMinY, spawnMaxY)), Quaternion.identity);
        numberOfPlatforms++;
    }

   

    
}
