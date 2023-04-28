using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPatroll : MonoBehaviour
{
    public float speed;
    public Transform[] wayPoints;
    public float waitTime;
    int currentPointIndex;

    bool once;

    public int damage;

    public int life;

    MovimentoPlayer player;

    void Start()
    {
        player = FindObjectOfType<MovimentoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != wayPoints[currentPointIndex].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentPointIndex].position, speed * Time.deltaTime);
        }
        else
        {
            if(once == false)
            {
                once = true;
                StartCoroutine(Wait());
            }
            
        }

        CheckDeath();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        if (currentPointIndex + 1 < wayPoints.Length )
        {
            currentPointIndex++;
        }
        else
        {
            currentPointIndex = 0;
        }
        once = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!player.isInvinceble)
            {
                player.life -= damage;
                player.isInvinceble = true;
            }
            else
            {
                return;
            }
            
        }
    }

    public void CheckDeath()
    {
        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
