using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HorizontalController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float wallJumpForce = 8f;
    public float wallJumpHorizontalForce = 4f;
    public Transform groundCheck;
    public Transform wallCheck;
    public float groundDistance = 0.2f;
    public float wallDistance = 0.2f;
    public LayerMask groundMask;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private bool isTouchingWall = false;
    private bool isFacingRight = true;
    private int jumpCount = 0;
    private int maxJumps = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if the player has pressed the jump button
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded || jumpCount < maxJumps)
            {
                // Increment the jump count
                jumpCount++;

                // Set the y-velocity of the rigidbody to the jump force
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            else if (isTouchingWall && !isGrounded)
            {
                // Set the x and y velocity of the rigidbody to the wall jump force
                float horizontalVelocity = isFacingRight ? -wallJumpHorizontalForce : wallJumpHorizontalForce;
                rb.velocity = new Vector2(horizontalVelocity, wallJumpForce);
            }
        }
    }

    void FixedUpdate()
    {
        // Check if the character is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundDistance, groundMask);

        // Check if the character is touching a wall
        isTouchingWall = Physics2D.Raycast(wallCheck.position, transform.right, wallDistance, groundMask);

        if (isGrounded)
        {
            // Reset the jump count
            jumpCount = 0;
        }

        // Move the character
        rb.velocity = new Vector2(moveSpeed * (isFacingRight ? 1 : -1), rb.velocity.y);

        // Check if the character has hit a tile and flip direction if necessary
        RaycastHit2D hit = Physics2D.Raycast(transform.position, isFacingRight ? Vector2.right : Vector2.left, 0.5f, groundMask);
        if (hit.collider != null)
        {
            isFacingRight = !isFacingRight;
        }

        // Flip the character's sprite based on its direction
        transform.localScale = new Vector3(isFacingRight ? 1 : -1, 1, 1);
    }
}
