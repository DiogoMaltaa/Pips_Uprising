using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBall : MonoBehaviour
{
    public float speed = 20f;

    public Rigidbody2D rb;

    public int damage = 3;


    void Start()
    {
        rb.velocity = -transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<MovimentoPlayer>().life -= damage;
        }
    }
}

