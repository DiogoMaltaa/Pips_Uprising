using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public BolaNeve bola;
    public float duracaoEfeitoGelo;
    public Image iceBar;
    float time;
    public GameObject iceUI;
    public GameObject pauseMenu;
    LevelLoader ll;

    void Start()
    {
        time = duracaoEfeitoGelo;
        iceUI.SetActive(false);

        ll = FindObjectOfType<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {

        print("isIce:" + bola.isIce);

        if(bola.isIce == false)
        {
            time = duracaoEfeitoGelo;
            iceUI.SetActive(false);
        }
        if(bola.isIce == true)
        {
            iceUI.SetActive(true);
        }
        time -= Time.deltaTime;
        iceBar.fillAmount = time / duracaoEfeitoGelo;

        

    }

    public void startIceEffect()
    {
        StartCoroutine(iceEffect());
        
    }

    IEnumerator iceEffect()
    {
        bola.isIce = true;
        yield return new WaitForSeconds(duracaoEfeitoGelo);       
        bola.isIce = false;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void ReturnToMenu(string menu)
    {
        Time.timeScale = 1;
        ll.LoadNextLevel(menu);
    }
}
