using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossAI : MonoBehaviour
{
    public Sprite normal;
    public Sprite half;
    public Sprite almostded;

    public SpriteRenderer spr;
    public float health;

    LevelLoader ll;
    public string winLevel;

    public Image healthBar;

    public float maxHealth;

    void Start()
    {

        health = maxHealth;
        ll = FindObjectOfType<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 50)
        {
            spr.sprite = normal;
        }

        if(health <= 35)
        {
            spr.sprite = half;
        }

        if(health <= 25)
        {
            spr.sprite = almostded;
        }

        if(health <= 0)
        {
            ll.LoadNextLevel(winLevel);
        }

        healthBar.fillAmount = health / maxHealth;
    }
}
