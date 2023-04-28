using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaNeve : MonoBehaviour
{

    public float speed = 20f;

    public bool isIce;

    public SpriteRenderer currentSprite;
    public Rigidbody2D rb;

    public Sprite normalSprite;
    public Sprite iceSprite;

    public int damage;
    public int currentDamage;

    public float iceEffectDuration;
    public float startIceEffectDuration = 10f;

    void Start()
    {
        rb.velocity = transform.right * speed;

        iceEffectDuration = startIceEffectDuration;

        currentSprite = GetComponent<SpriteRenderer>();
        currentDamage = damage;
    }

    // Update is called once per frame
    void Update()
    {
        if(isIce == true)
        {
            currentSprite.sprite = iceSprite;
            damage = 3;
            iceEffectDuration -= Time.deltaTime;
        }

        else
        {
            currentSprite.sprite = normalSprite;
            damage = 1;
        }

        currentDamage = damage;

        if (!currentSprite.isVisible)
        {
            Destroy(gameObject);
        }

        if (iceEffectDuration <= 0)
        {
            isIce = false;
            iceEffectDuration = startIceEffectDuration;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<BasicPatroll>().life -= damage;
            Destroy(gameObject);
        }
    }
}
