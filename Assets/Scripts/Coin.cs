using UnityEngine;

public class Coin : MonoBehaviour
{
    void Start()
    {
        
        Debug.Log("Script da moeda carregado no objeto: " + gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        Debug.Log("Algo entrou no trigger da moeda: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player detectado! Destruindo moeda...");
            Destroy(gameObject);
            GameManager.score += 1;
        }

    }
}