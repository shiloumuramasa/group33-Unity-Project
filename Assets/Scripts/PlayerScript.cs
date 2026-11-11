using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;



public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 8f;
    public float jumpForce = 14f;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;

    private float moveInput;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        ReadInput();

        if (transform.position.y < -30)
        {
            Die();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void ReadInput()
    {
        Keyboard kb = Keyboard.current;

        moveInput = 0;

        if (kb.aKey.isPressed) moveInput = -1f;
        if (kb.dKey.isPressed) moveInput = 1f;

        if (kb.spaceKey.wasPressedThisFrame) Jump();
    }
    private void Move()
    {
        rb.linearVelocityX = moveInput * moveSpeed;
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            rb.linearVelocityY = jumpForce;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void Die()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainGame");
    }

}