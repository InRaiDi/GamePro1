using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public bool facingRight = true;

    Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if (Input.GetAxis("Horizontal") < 0.0 && facingRight) //I'll do this better later.
        {
            Flip();
        }
        else if (Input.GetAxis("Horizontal") > 0.0 && !facingRight)
        {
            Flip();
        }

    }

    private void Flip()
    {
        facingRight = !facingRight;      
        
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;                
        transform.localScale = theScale;
    }
}

