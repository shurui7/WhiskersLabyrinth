using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public float speed = 5f;
    private int direction = 1;
    public float LimitLeft = 0;
    public float LimitRight = 0;
    private bool isFacingRight = true;
    public bool IsDead;
    public bool IsHurt;
    [SerializeField] private Animator anim;

    void Update()
    {
        IsDead = anim.GetBool("IsDead");
        IsHurt = anim.GetBool("IsHurt");

        // Check if the NPC is dead and disable this script
        if (IsDead)
        {
            anim.SetBool("IsWalking", false);
            this.enabled = false;
            return; // Exit the Update function to stop further execution
        }

        if (IsHurt)
        {
            anim.SetBool("IsWalking", false);
        }


        if (!IsHurt)
        {
            Vector3 movement = new Vector3(direction, 0f, 0f);
            transform.Translate(movement * speed * Time.deltaTime);
            anim.SetBool("IsWalking", true);

            if (transform.position.x < LimitLeft)
            {
                direction = 1;
                Flip();
            }
            else if (transform.position.x > LimitRight)
            {
                direction = -1;
                Flip();
            }

            if (Mathf.Abs(direction) > 0.1f)
            {
                anim.SetBool("IsWalking", true);
            }
            else
            {
                anim.SetBool("IsWalking", false);
            }
        }


    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}