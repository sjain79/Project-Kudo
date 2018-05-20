using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerScript>().StartRocket();
            Destroy(gameObject);
        }
    }
}
