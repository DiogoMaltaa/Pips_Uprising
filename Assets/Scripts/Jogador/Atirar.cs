using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour
{

    public Transform shootingPoint;
    public FixedButton shootingButton;
    public GameObject bulletPrefab;

    public float timeShoot;
    float timeBeforeShooting;

    public AudioSource shooting;

    private void Start()
    {
        timeBeforeShooting = timeShoot;
    }

    // Update is called once per frame
    void Update()
    {
        if (shootingButton.Pressed && timeBeforeShooting <= 0f)
        {
            Shoot();
        }
        else
        {
            timeBeforeShooting -= Time.deltaTime;
        }
    }

    public void Shoot()
    {
        shooting.Play();
        Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
        timeBeforeShooting = timeShoot;
    }
}
