using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPackScript : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    float speed;

    private void OnEnable()
    {
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
        Invoke("EndEffect", 3);
    }

    private void Update()
    {
        player.transform.Translate(Vector2.up * speed * Time.unscaledDeltaTime);
    }

    private void OnDisable()
    {
        player.GetComponent<Rigidbody2D>().gravityScale =1;
    }

    private void EndEffect()
    {
        player.GetComponent<PlayerScript>().rocketIsOn = false;
        gameObject.SetActive(false);
    }
}
