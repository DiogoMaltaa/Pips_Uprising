using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPlayer : MonoBehaviour
{
    [Header("Basic Info")]
    [SerializeField]
    private float horizontal;
    private float speed = 8f;
    private bool isFacingRight = true;

    [Header("Jump Info")]
    [SerializeField]
    private float jumpPower = 16f;

    [Header("Other Components")]
    [SerializeField]
    private Rigidbody2D rb;
    private Transform groundCheck;
    private LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        if(Input.GetButtonUp("JUmp") && rb.velocity.y > 0)
        {

        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed * Time.deltaTime, rb.velocity.y);
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
