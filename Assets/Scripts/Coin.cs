using UnityEngine;

public class Coin : MonoBehaviour
{
    private AudioSource coinSound;

    void Start()
    {
        coinSound = GameObject.Find("CoinSound").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (coinSound != null)
                coinSound.Play();

            GameManager.score += 1;
            Destroy(gameObject);
        }
    }
}