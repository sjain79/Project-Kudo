using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingManMovement : MonoBehaviour {

    [SerializeField]
    float speed,strength;

    private void Update()
    {
        Vector2 newPosition = transform.position;
        newPosition.x = Mathf.Sin(Time.time * speed) * strength;
        transform.position = newPosition;
    }
}
