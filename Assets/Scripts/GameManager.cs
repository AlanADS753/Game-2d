using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int score;

    private TextMeshProUGUI scoreText;

 
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    
    void Update()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();

        scoreText.text = score.ToString();
    }
}