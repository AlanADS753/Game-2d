using UnityEngine;

public class SlimePatrulha : MonoBehaviour
{
    public float velocidade = 2f;
    public float distancia = 3f;

    private Vector3 posicaoInicial;
    private bool indoDireita = true;

    void Start()
    {
        posicaoInicial = transform.position;
    }

    void Update()
    {
        if (indoDireita)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);

            if (transform.position.x >= posicaoInicial.x + distancia)
            {
                indoDireita = false;

                Vector3 escala = transform.localScale;
                escala.x = -Mathf.Abs(escala.x);
                transform.localScale = escala;
            }
        }
        else
        {
            transform.Translate(Vector2.left * velocidade * Time.deltaTime);

            if (transform.position.x <= posicaoInicial.x - distancia)
            {
                indoDireita = true;

                Vector3 escala = transform.localScale;
                escala.x = Mathf.Abs(escala.x);
                transform.localScale = escala;
            }
        }
    }
}