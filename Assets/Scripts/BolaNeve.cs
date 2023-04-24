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

    void Start()
    {
        rb.velocity = transform.right * speed;

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
        }

        else
        {
            currentSprite.sprite = normalSprite;
            damage = 1;
        }

        currentDamage = damage;
    }
}
