using UnityEngine;
using UnityEngine.SceneManagement;

public class DanoInimigo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entrou no trigger: " + collision.name);

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Jogador morreu!");

            GameManager.score = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}