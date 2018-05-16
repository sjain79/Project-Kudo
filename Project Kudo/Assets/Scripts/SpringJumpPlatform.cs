using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringJumpPlatform : MonoBehaviour
{
    [SerializeField]
    float jumpForce;

    bool wasUsed = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (!wasUsed)
                {
                    Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
                    Vector2 jumpVector = new Vector2(playerRb.velocity.x, jumpForce);
                    playerRb.velocity = jumpVector;

                    Animator springAnim = GetComponent<Animator>();
                    springAnim.SetTrigger("Spring Jump");

                    wasUsed = true;
                }
            }
        }
    }

}
