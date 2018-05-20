﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField]
    float smoothing;

    private GameObject player;
    private Vector3 newPosition;

    private Vector3 currentVelocity;

    bool isRocketOn;

    float maxSpeed = 2;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void LateUpdate()
    {
        if (player.transform.position.y > transform.position.y)
        {
            newPosition = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref currentVelocity, smoothing,maxSpeed, Time.deltaTime);
        }
    }

    private void Update()
    {
        if (isRocketOn)
        {
            maxSpeed = 7;
        }
        else
        {
            maxSpeed = 2;
        }
    }


}
