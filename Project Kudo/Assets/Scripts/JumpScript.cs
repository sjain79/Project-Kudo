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

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y >= 0f)
        {
            if (collision.gameObject.CompareTag("Platform"))
            {
                Vector2 jumpVector = new Vector2(playerRb.velocity.x, jumpForce);
                playerRb.velocity = jumpVector;
                //playerRb.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Background"))
        {
            Debug.Log("Player Death");
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
