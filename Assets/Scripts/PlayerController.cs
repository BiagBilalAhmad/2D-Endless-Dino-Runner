using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator animator;

    private Rigidbody2D rb;
    public bool isGrounded;

    public Collider2D slideCollider, capsuleCollider;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(GameManager.Instance.StartGame)
        {
            // Check if the player is grounded
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

            // Check for jump input and if the player is on the ground
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                Slide();
            }

            // Update animator parameters based on the player's state
            //animator.SetBool("IsGrounded", isGrounded);
            UpdateAnimations();
        }
       
    }

    void UpdateAnimations()
    {
        animator.SetBool("IsRunning", false);
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsFalling", false);

        if(isGrounded)
        {
            animator.SetBool("IsRunning", true);
            return;
        }

        if (!isGrounded)
        {
            if (rb.velocity.y > 0)
            {
                animator.SetBool("IsJumping", true);
            }
            else
            {

                animator.SetBool("IsFalling", true);
            }
        }
    }

    public void Jump()
    {
        if(isGrounded)
        {
            SoundManager.Instance.PlayMoveSound();
            // Apply a vertical force to make the player jump
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    public void Slide()
    {
        animator.SetTrigger("IsSliding");
        slideCollider.enabled = true;
        capsuleCollider.enabled = false;
    }
    public void NormalState()
    {
        slideCollider.enabled = false;
        capsuleCollider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Score"))
        {
            SoundManager.Instance.PlayCoinSound();
            GameManager.Instance.UpdateScore(50);

            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            animator.Play("dying");
            StartCoroutine(GameOver());            
        }
    }

    private IEnumerator GameOver()
    {
        SoundManager.Instance.PlayGameOverSound();
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.ShowGameOver();
    }
}
