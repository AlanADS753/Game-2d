using System.Collections;
using UnityEngine;

public class PeixePulo : MonoBehaviour
{
    public float forcaPulo = 8f;
    public float intervaloMin = 1.5f;
    public float intervaloMax = 3f;

    public Sprite piranhaUp;
    public Sprite piranhaDown;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        StartCoroutine(Pular());
    }

    void Update()
    {
        if (rb.linearVelocity.y > 0.1f)
        {
            sr.sprite = piranhaUp;
        }
        else if (rb.linearVelocity.y < -0.1f)
        {
            sr.sprite = piranhaDown;
        }
    }

    IEnumerator Pular()
    {
        while (true)
        {
            float espera = Random.Range(intervaloMin, intervaloMax);

            yield return new WaitForSeconds(espera);

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);

            rb.AddForce(
                Vector2.up * forcaPulo,
                ForceMode2D.Impulse
            );
        }
    }
}