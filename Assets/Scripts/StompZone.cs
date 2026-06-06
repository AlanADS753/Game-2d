using UnityEngine;

public class BeeStomp : MonoBehaviour
{
    public BeeAI bee;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();

        if (rb != null && rb.linearVelocity.y < 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 8f);
            bee.Matar();
        }
    }
}