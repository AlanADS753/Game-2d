using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathArea : MonoBehaviour
{
  
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GameManager.score = 0;
        }
    }
}