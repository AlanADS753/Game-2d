using UnityEngine;

public class Coin : MonoBehaviour
{
    void Start()
    {
        // Se esta mensagem não aparecer no Console ao dar Play, 
        // o script não está anexado ao objeto da moeda!
        Debug.Log("Script da moeda carregado no objeto: " + gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Se esta mensagem não aparecer ao tocar na moeda, 
        // o problema é colisão (Tag ou Is Trigger)
        Debug.Log("Algo entrou no trigger da moeda: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player detectado! Destruindo moeda...");
            Destroy(gameObject);
            GameManager.score += 1;
        }

    }
}