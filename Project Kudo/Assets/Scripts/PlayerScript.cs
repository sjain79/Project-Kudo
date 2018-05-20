using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D playerRb;
    JumpScript myJumpScript;

    [SerializeField]
    float diedUpForce;

    public int coins;
    public bool isInBubble;

    [SerializeField]
    GameObject rocket;

    public bool rocketIsOn;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        myJumpScript = GetComponent<JumpScript>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isInBubble && !rocketIsOn)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isInBubble && !rocketIsOn)
        {
            if (collision.gameObject.CompareTag("Background") || collision.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Player Death");
            }
        }
    }

    private void Update()
    {
        Debug.Log("Coins " + coins);
    }

    public void StartRocket()
    {
        rocket.SetActive(true);
        rocketIsOn = true;
    }

    private void Start()
    {
        rocket.SetActive(false);
        rocketIsOn = false;
    }
}
