using JetBrains.Annotations;
using UnityEngine;

public class HorizontalController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float wallJumpForce = 4f;
    public float wallJumpHorizontalForce = 4f;
    public Transform groundCheck;
    public Transform wallCheck;
    public float groundDistance = 0.2f;
    public float wallDistance = 0.2f;
    public float coyoteTime = 0.2f;
    public LayerMask groundMask;
    public bool isGrounded = false;

    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D groundLeaveCheck;
    private bool isTouchingWall = false;
    public bool isFacingRight = true;
    private float coyoteTimeLeft = 0f;

    private bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        groundLeaveCheck = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        // Check if the player has pressed the jump button
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                Jump();
            }
            else if (!isGrounded && coyoteTimeLeft > 0)
            {
                Jump();
            }
            if (!isGrounded && isTouchingWall)
            {
                WallJump();
            }
        }

        anim.SetBool("Grounded", isGrounded);

        // Check if the character is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundDistance, groundMask);

        // Check if the character is touching a wall
        isTouchingWall = Physics2D.Raycast(wallCheck.position, isFacingRight ? Vector2.right : Vector2.left, wallDistance, groundMask);

        if (isGrounded)
        {
            // Reset Coyote Time
            coyoteTimeLeft = coyoteTime;
        }
        else
        {
            // decrement coyote time
            coyoteTimeLeft -= Time.deltaTime;
        }

        if (rb.velocity.y < 0 && isGrounded)
        {
            isJumping = false;
        }


        // Check if the character has hit a tile and flip direction if necessary
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, isFacingRight ? Vector2.right : Vector2.left, 0.5f, groundMask);
        if(isTouchingWall && isGrounded)
        {
            isFacingRight = !isFacingRight;
        }

        else if (isTouchingWall && !isGrounded)
        {
            isFacingRight = !isFacingRight;
            rb.AddForce((isFacingRight ? new Vector2(1, 1) * wallJumpForce : new Vector2(-1, 1) * wallJumpForce), ForceMode2D.Impulse);
        }

        // Flip the character's sprite based on its direction
        transform.localScale = new Vector3(isFacingRight ? -1 : 1, 1, 1);
    }

    void FixedUpdate()
    {

        // Move the character
        rb.velocity = new Vector2(moveSpeed * (isFacingRight ? 1 : -1), rb.velocity.y);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isJumping)
            return;

        if (collision != null)
        {
            Debug.Log("Collider Exited: " + isFacingRight, this.gameObject);
            isFacingRight = !isFacingRight;
        }
    }

    void Jump()
    {
        if (isTouchingWall && isGrounded)
        {
            WallJump();
            coyoteTimeLeft = coyoteTime;
        }
        else if(!isJumping)
        {
            //jumpCount++;

            //the condition:
            //if(jumpCount < 2)

            // Set the y-velocity of the rigidbody to the jump force
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            coyoteTimeLeft = 0.0f;
            isJumping = true;
        }
    }

    void WallJump()
    {
        // Set the x and y velocity of the rigidbody to the wall jump force
        float horizontalVelocity = isTouchingWall && isFacingRight ? -wallJumpHorizontalForce : wallJumpHorizontalForce;
        rb.velocity = new Vector2(horizontalVelocity, wallJumpForce);

        // Flip the character's direction based on the wall it is jumping off of
        isFacingRight = isTouchingWall ? !isFacingRight : isFacingRight;
        transform.localScale = new Vector3(isFacingRight ? 1 : -1, 1, 1);
    }
}
