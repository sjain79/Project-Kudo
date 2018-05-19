using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{

    [SerializeField]
    float jumpForce;

    [SerializeField]
    Sprite normalSprite;

    Rigidbody2D playerRb;
    SpriteRenderer playerSpriteRenderer;

    PlayerScript playerScript;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        playerScript = GetComponent<PlayerScript>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!playerScript.isInBubble)
        {
            if (collision.relativeVelocity.y >= 0f)
            {
                if (collision.gameObject.CompareTag("Platform"))
                {
                    Vector2 jumpVector = new Vector2(playerRb.velocity.x, jumpForce);
                    playerRb.velocity = jumpVector;
                }
            }
        }
    }

   

    private void Update()
    {
        if (playerRb.velocity.y < 0)
        {
            playerSpriteRenderer.sprite = normalSprite;
        }
    }
}
