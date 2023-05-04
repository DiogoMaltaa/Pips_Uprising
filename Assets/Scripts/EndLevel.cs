using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    LevelLoader level;
    public string scene;

    void Start()
    {
        level = FindObjectOfType<LevelLoader>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            level.LoadNextLevel(scene);
        }
    }
}
