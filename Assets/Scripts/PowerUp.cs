using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private BolaNeve bola;
    GameManager game;

    public AudioSource powerUP;
    public void Start()
    {
        game = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            powerUP.Play();
            game.startIceEffect();
            Destroy(gameObject);
        }
    }
}
