using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovimentoPlayer : MonoBehaviour
{
    public CharacterController2D controller;

    [Header("Parameters")]
    public float runSpeed = 40f;
    public Joystick joystick;
    public FixedButton jumpButton;
    bool jump = false;

    float horizontalMove = 0f;

    public float life;

    public Image healthBar;

    public bool isInvinceble;
    public float timeWithInvicibility;

    public Animator anim;

    float currentHealth;
    public float maxHealth = 5f;

    public string sceneName;


    

    private void Start()
    {
        healthBar.fillAmount = life / 100;
        currentHealth = life;
    }

    private void Update()
    {
        currentHealth = life;
        healthBar.fillAmount = currentHealth / maxHealth;

        horizontalMove = joystick.Horizontal * runSpeed;

        if (jumpButton.Pressed)
        {
            jump = true;     
        }

        CheckDeath();

        if(isInvinceble == true)
        {
            StartCoroutine(Invinceble());
        }

        anim.SetFloat("speed", horizontalMove);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void CheckDeath()
    {
        if(life <= 0)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    IEnumerator Invinceble()
    {
        yield return new WaitForSeconds(timeWithInvicibility);
        isInvinceble = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            life = 0;
        }

    }
}

