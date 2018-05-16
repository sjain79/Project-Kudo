using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnInvisible : MonoBehaviour {

    private void OnBecameVisible()
    {
        Destroy(gameObject);
    }
}
