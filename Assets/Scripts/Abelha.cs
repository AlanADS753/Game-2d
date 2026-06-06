using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeeAI : MonoBehaviour
{
    public float velocidadePatrulha = 2f;
    public float velocidadeAtaque = 5f;
    public float distanciaPatrulha = 3f;
    public float distanciaDeteccao = 5f;
    public float tempoAtaque = 2f;
    public float tempoDescanso = 2f;

    public Sprite beeDeadSprite;

    private Transform player;
    private Vector3 posicaoInicial;

    private bool indoDireita = true;
    private bool atacando = false;
    private bool descansando = false;
    private bool morreu = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        posicaoInicial = transform.position;
    }

    void Update()
    {
        if (morreu)
            return;

        if (descansando)
            return;

        if (atacando)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                velocidadeAtaque * Time.deltaTime);

            return;
        }

        float distancia = Vector2.Distance(
            transform.position,
            player.position);

        if (distancia <= distanciaDeteccao)
        {
            StartCoroutine(Atacar());
            return;
        }

        Patrulhar();
    }

    void Patrulhar()
    {
        if (indoDireita)
        {
            transform.Translate(Vector2.right * velocidadePatrulha * Time.deltaTime);

            if (transform.position.x >= posicaoInicial.x + distanciaPatrulha)
                indoDireita = false;
        }
        else
        {
            transform.Translate(Vector2.left * velocidadePatrulha * Time.deltaTime);

            if (transform.position.x <= posicaoInicial.x - distanciaPatrulha)
                indoDireita = true;
        }
    }

    IEnumerator Atacar()
    {
        atacando = true;

        yield return new WaitForSeconds(tempoAtaque);

        atacando = false;

        while (Vector2.Distance(transform.position, posicaoInicial) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                posicaoInicial,
                velocidadePatrulha * Time.deltaTime);

            yield return null;
        }

        descansando = true;

        yield return new WaitForSeconds(tempoDescanso);

        descansando = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (morreu)
            return;

        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.score = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Matar()
    {
        if (!morreu)
        {
            StartCoroutine(Morrer());
        }
    }

    IEnumerator Morrer()
    {
        morreu = true;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        if (sr != null && beeDeadSprite != null)
            sr.sprite = beeDeadSprite;

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