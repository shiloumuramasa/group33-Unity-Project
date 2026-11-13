
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Hierarchy;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

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

        if (moveInput != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

    }
    private void Move()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

<<<<<<< HEAD
<<<<<<< HEAD
}
=======
}
>>>>>>> parent of f1213ce (Fixed bounce pad)
=======
}
>>>>>>> parent of f1213ce (Fixed bounce pad)
