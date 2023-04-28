using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPlayer : MonoBehaviour
{
    public CharacterController2D controller;

    [Header("Parameters")]
    public float runSpeed = 40f;
    public Joystick joystick;
    public FixedButton jumpButton;
    bool jump = false;

    float horizontalMove = 0f;

    public int life;

    public bool isInvinceble;
    public float timeWithInvicibility;

    public Animator anim;

    private void Update()
    {
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
            Debug.Log("Player is DED");
        }
    }

    IEnumerator Invinceble()
    {
        yield return new WaitForSeconds(timeWithInvicibility);
        isInvinceble = false;
    }
}

