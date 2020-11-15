using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ~~~~ Script for player controls ~~~~

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
  
    private float movementInputDirection;
    private bool isFacingRight = true;
    private bool isWalking;
    private bool isGrounded;
    private bool canJump;

    Transform playerGraphics;       // reference to graphics so we can change direction

    public Transform arm;
    public float movementSpeed = 10.0f;
    public float jumpForce = 5.0f;
   
    public Transform groundCheck;
    public float groundCheckRadius;

    public LayerMask whatIsGround;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();                    // player rigidbody reference
        anim = GetComponent<Animator>();                     // player animator reference

    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        CheckMovementDirection();
        UpdateAnimations();
        CheckifcanJump();
      //  Pivot();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
        CheckSurroundings();
    }

    private void CheckSurroundings()                            // function to check ground with wireframe circle
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    private void CheckifcanJump()                               // jump conditions
    {
        if (isGrounded && rb.velocity.y <= 0.5)
        {
            canJump = true;                                     // player on ground and its y direction is going below player sprite's current y position - can jump
        }
        else
        {
            canJump = false;                                    // else can't jump
        }
    }


    private void CheckMovementDirection()
    {
        if (isFacingRight && movementInputDirection < 0)        // if player is facing right and user input is going < 0 (left)
        {
            Flip();                                             // then flip sprite to the left                                                 
        }
        else if (!isFacingRight && movementInputDirection > 0)  // if NOT facing right and player is going > 0 (right)
        {
            Flip();                                             // flip back to right
        }


        if (rb.velocity.x != 0)                                // determine if walking by change in sprite x velocity
        {
            isWalking = true;                        
        }
        else
        {
            isWalking = false;
        }
    }

    private void UpdateAnimations()
    {
        anim.SetBool("isWalking", isWalking);                  // if walking then animator parameter is set to 'isWalking'
        anim.SetBool("isGrounded", isGrounded);                // if on ground then animator parameter is set to 'isGrounded'
       
    }

    private void CheckInput()
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal");    // returns key input A or D/left right arrow

        if (Input.GetButtonDown("Jump"))
        {
            Jump();                                                 // jump when jump button is pressed
        }

    }


    private void Jump()                                             // jump function
    {
        if (canJump)                                                // if on ground
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);      // adds set force to y 
        } 
    }


    private void ApplyMovement()
    {
        rb.velocity = new Vector2(movementSpeed * movementInputDirection, rb.velocity.y);   // move rigidbody component with set velocity
    }


    private void Flip()                                           // flip sprite function
    {
        isFacingRight = !isFacingRight;         
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    private void OnDrawGizmos()                                 // creates a wireframe circle
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            transform.gameObject.GetComponent<Renderer>().material.color = Color.Lerp(Color.red, Color.red, 1.0f);
        }
    }

/*    void Pivot()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10.0f;                                             //The distance from the camera to the arm object
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);     // convert point from screen space to world space
        lookPos = lookPos - transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;    // returns angle values from mouse position
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);  // takes the mouse angle and rotates arm from pivot
    }*/


}
