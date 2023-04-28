using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BolaNeve bola;
    public float duracaoEfeitoGelo;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startIceEffect()
    {
        StartCoroutine(iceEffect());
    }

    IEnumerator iceEffect()
    {
        Debug.Log("Ice Effect Started");
        bola.isIce = true;
        yield return new WaitForSeconds(duracaoEfeitoGelo);
        Debug.Log("Ice Effect is Over");
        bola.isIce = false;
    }
}
