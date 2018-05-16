using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushScript : MonoBehaviour
{
    [SerializeField]
    float width;

    private void Start()
    {
        transform.localPosition = new Vector2(Random.Range(-width, width), 0.421f);
    }
}
