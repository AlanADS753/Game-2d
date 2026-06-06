using UnityEngine;

public class Barnacle : MonoBehaviour
{
    public float alturaSubida = 2f;
    public float velocidade = 2f;
    public float tempoParada = 2f;

    private Vector3 posicaoInicial;
    private Vector3 posicaoTopo;

    private bool subindo = true;
    private bool esperando = false;

    void Start()
    {
        posicaoInicial = transform.position;
        posicaoTopo = posicaoInicial + Vector3.up * alturaSubida;
    }

    void Update()
    {
        if (esperando)
            return;

        if (subindo)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                posicaoTopo,
                velocidade * Time.deltaTime);

            if (Vector3.Distance(transform.position, posicaoTopo) < 0.01f)
            {
                StartCoroutine(Esperar());
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                posicaoInicial,
                velocidade * Time.deltaTime);

            if (Vector3.Distance(transform.position, posicaoInicial) < 0.01f)
            {
                StartCoroutine(Esperar());
            }
        }
    }

    System.Collections.IEnumerator Esperar()
    {
        esperando = true;

        yield return new WaitForSeconds(tempoParada);

        subindo = !subindo;
        esperando = false;
    }
}