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

    float lastPlatformY= -3.08f;

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
        //TODO: Make the spawning of type of platform random too
        Instantiate(platformPrefabs[0], new Vector2(Random.Range(-screenWidth, screenWidth), lastPlatformY += Random.Range(spawnMinY, spawnMaxY)), Quaternion.identity);
        numberOfPlatforms++;
    }

   

    
}
