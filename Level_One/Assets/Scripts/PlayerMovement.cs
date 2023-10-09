using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Animator animator;

    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    private bool doubleJump;

    private Vector4 respawnPoint;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private Transform fallDetector;
    private float doubleJumpingPower = 12f;
    void Start()
    {
        respawnPoint = transform.position;
    }
    // Update is called once per frame
  
    void Update()
    {
                
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        
        horizontal = Input.GetAxisRaw("Horizontal");
        

        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }

        if(Input.GetButtonDown("Jump"))
        {
            animator.SetBool("IsJumping", true);
            
            if (IsGrounded() || doubleJump)
            
            {
                rb.velocity = new Vector2(rb.velocity.x, doubleJump ? doubleJumpingPower : jumpingPower);

                doubleJump = !doubleJump;
            }
            
            
        }

        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        
        Flip();
        }
    

public void OnLanding()
        {
            animator.SetBool("IsJumping", false);
        }
    public void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Spikes")
        {
            transform.position = respawnPoint;
        }
    }
}
