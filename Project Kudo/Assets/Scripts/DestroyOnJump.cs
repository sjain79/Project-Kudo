using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnJump : MonoBehaviour {

    [SerializeField]
    GameObject platformBreakingPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Instantiate(platformBreakingPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
