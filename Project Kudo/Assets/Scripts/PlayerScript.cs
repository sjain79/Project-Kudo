using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D playerRb;
    JumpScript myJumpScript;

    [SerializeField]
    float diedUpForce;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        myJumpScript = GetComponent<JumpScript>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            myJumpScript.enabled = false;
            playerRb.velocity = new Vector2(playerRb.velocity.x, diedUpForce);
            playerRb.GetComponent<Collider2D>().enabled = false;
            Debug.Log("Player Died");
        }
    }
}
