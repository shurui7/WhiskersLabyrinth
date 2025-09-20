using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float speed = 5f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    private bool isAttacking = false;
    private Vector3 StartingPos;

    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


    private void Start()
    {
        StartingPos = transform.position;
    }
    void Update()
    {
        // Check if the player is attacking
        if (!isAttacking)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }

            Flip();
        }
    }

    private void FixedUpdate()
    {
        // Check if the player is attacking
        if (!isAttacking)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            if (Mathf.Abs(horizontal) > 0.1f)
            {
                anim.SetBool("running", true);
            }
            else
            {
                anim.SetBool("running", false);
            }

            if (Mathf.Abs(rb.velocity.y) > 0.1f)
            {
                anim.SetBool("jumping", true);
            }
            else
            {
                anim.SetBool("jumping", false);
            }
        }
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

    public void SetIsAttacking(bool value)
    {
        isAttacking = value;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            Debug.Log("Player collided with spikes!");
            ResetPlayerPosition();
        }
    }

    private void ResetPlayerPosition()
    {
        transform.position = StartingPos;
    }
}
