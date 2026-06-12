using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jump = 10f;
    public float climbSpeed = 3f;

    private AudioSource jumpSound;

    private bool isMooving;
    public Animator anim;
    public SpriteRenderer sprite;
    
    private float move;
    private bool isOnFloor;
    public bool isOnLadder;

    public Rigidbody2D rb;

    void Start()
    {
        jumpSound = GameObject.Find("JumpSound").GetComponent<AudioSource>();
    }

    void Update()
    {
        move = Input.GetAxis("Horizontal");

        if (isOnLadder)
        {
            float climbMove = Input.GetAxis("Vertical");
            rb.linearVelocity = new Vector2(0, climbMove * climbSpeed);
            rb.gravityScale = 0f;

            anim.SetBool("isClimbing", climbMove != 0);

            if (Input.GetButtonDown("Jump"))
            {
                rb.gravityScale = 1f;
                isOnLadder = false;
                anim.SetBool("isClimbing", false);
                rb.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
                jumpSound.Play();
            }
        }
        else
        {
            rb.gravityScale = 1f;
            anim.SetBool("isClimbing", false);
            rb.linearVelocity = new Vector2(move * speed, rb.linearVelocityY);

            if (Input.GetButtonDown("Jump") && isOnFloor)
            {
                rb.AddForce(new Vector2(rb.linearVelocityX, jump), ForceMode2D.Impulse);
                isOnFloor = false;
                jumpSound.Play();
            }
        }

        if (move > 0)
        {
            isMooving = true;
            sprite.flipX = false;
        }
        else if (move < 0)
        {
            isMooving = true;
            sprite.flipX = true;
        }
        else
        {
            isMooving = false;
        }

        anim.SetBool("isMooving", isMooving);
        anim.SetBool("isOnFloor", isOnFloor);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnFloor = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            isOnLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            isOnLadder = false;
            rb.gravityScale = 1f;
            anim.SetBool("isClimbing", false);
        }
    }
}