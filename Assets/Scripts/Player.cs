using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jump = 10f;

    private bool isMooving;
    public Animator anim;
    public SpriteRenderer sprite;
    
    private float move;
    private bool isOnFloor;

    public Rigidbody2D rb;

    void Update()
    {
        move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocityY);

        if (Input.GetButtonDown("Jump") && isOnFloor)
        {
           
            rb.AddForce(new Vector2(rb.linearVelocityX, jump), ForceMode2D.Impulse);
            
          
            isOnFloor = false;
        }

        if (move > 0)
        {
            isMooving = true;
            sprite.flipX = false;
        }
        else if(move < 0)
        {
            isMooving = true;
            sprite.flipX = true;
        }
        else
        {
            isMooving = false;
        }   


        anim.SetBool("isMooving", isMooving);
        anim.SetBool("isOnFloor", isMooving);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnFloor = true;
        }
    }
}