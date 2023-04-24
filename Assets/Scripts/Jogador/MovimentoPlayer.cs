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

    private void Update()
    {
        horizontalMove = joystick.Horizontal * runSpeed;

        if (jumpButton.Pressed)
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
