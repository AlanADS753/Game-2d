using System.Collections;
using UnityEngine;

public class MorcegaAI : MonoBehaviour
{
    public float velocidadeNormal = 6f;
    public float velocidadeNaCorrente = 2f;
    public float distanciaDeteccao = 7f;

    public Sprite morcegaDeadSprite;

    private Transform player;
    private Player playerScript;
    private bool morreu = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerScript = player.GetComponent<Player>();
    }

    void Update()
    {
        if (morreu)
            return;

        float distancia = Vector2.Distance(transform.position, player.position);

        if (distancia <= distanciaDeteccao)
        {
            float velocidade = playerScript.isOnLadder ? velocidadeNaCorrente : velocidadeNormal;

            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                velocidade * Time.deltaTime);
        }
    }

    public void Matar()
    {
        if (!morreu)
            StartCoroutine(Morrer());
    }

    IEnumerator Morrer()
    {
        morreu = true;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null && morcegaDeadSprite != null)
            sr.sprite = morcegaDeadSprite;

        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
            col.enabled = false;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 2f;
            rb.linearVelocity = Vector2.zero;
        }

        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}