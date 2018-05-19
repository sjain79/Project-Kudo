using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{

    bool activated;
    GameObject player;

    bool ascendStarted;

    [SerializeField]
    float speed;

    float effectSpeed = 3;

    Rigidbody2D bubbleRb;

    private void Awake()
    {
        bubbleRb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!activated)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                Debug.Log("Player stppoed from jumpinmg");
                collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                activated = true;
                ascendStarted = true;
                player = collision.gameObject;
                player.GetComponent<PlayerScript>().isInBubble = true;
                Invoke("AscendComplete", 2);
            }
        }
    }

    private void Update()
    {
        if (activated)
        {
            Debug.Log("Start ascend");
            player.transform.position = gameObject.transform.position;
            StartAscend();

        }
    }

    private void AscendComplete()
    {
        activated = false;
        player.GetComponent<PlayerScript>().isInBubble = false;
        player.GetComponent<Rigidbody2D>().gravityScale = 1;
        Destroy(gameObject);
    }

    private void StartAscend()
    {
        if (ascendStarted)
        {
            ascendStarted = false;
            bubbleRb.velocity = Vector2.down * effectSpeed;
            bubbleRb.gravityScale = -0.5f;
        }
    }
}
