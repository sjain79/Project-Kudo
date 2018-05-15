using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float horizontalMovementMultiplier;

    Vector2 movement;

    Rigidbody2D playerRb;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal") * horizontalMovementMultiplier, playerRb.velocity.y);
    }

    private void FixedUpdate()
    {
        playerRb.velocity = movement;
    }
}