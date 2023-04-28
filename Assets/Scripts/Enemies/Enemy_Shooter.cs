using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shooter : MonoBehaviour
{

    public GameObject projectilePrefab;
    private float distance;
    public Transform shooter;
    public float maxDistance;

    int index;

    public Animator anim;

    public float delayToShoot;

    // Start is called before the first frame update
    void Start()
    {
        distance = maxDistance - transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 10f, LayerMask.GetMask("Player"));
        if (hit.collider != null)
        {
            if (delayToShoot <= 0)
            {
                Shoot();
                anim.SetBool("shooting", true);
            }
            else
            {
                delayToShoot -= Time.deltaTime;
                anim.SetBool("shooting", false);
            }

        }
    }
    public void Shoot()
    {
        Instantiate(projectilePrefab, shooter.position, Quaternion.identity);
        delayToShoot = 1f;
    }

}
