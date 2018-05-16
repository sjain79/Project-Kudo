using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour {

    private void OnBecameInvisible()
    {
        Debug.Log("Destroyed the platform");
        LevelGenerator.numberOfPlatforms--;
        Destroy(gameObject);
    }
}
