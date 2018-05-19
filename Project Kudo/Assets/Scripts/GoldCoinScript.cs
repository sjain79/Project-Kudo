using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoinScript : MonoBehaviour {

    [SerializeField]
    GameObject goldCoinEffectPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerScript>().coins++;
            Instantiate(goldCoinEffectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
