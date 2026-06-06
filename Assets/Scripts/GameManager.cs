using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int score;
    public static GameManager instance;
    private TextMeshProUGUI scoreText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        BuscaScoreText();
    }

    void BuscaScoreText()
    {
        GameObject obj = GameObject.Find("ScoreText");
        if (obj != null)
        {
            scoreText = obj.GetComponent<TextMeshProUGUI>();
            Debug.Log("ScoreText encontrado!");
        }
        else
        {
            Debug.LogError("ScoreText NAO encontrado!");
        }
    }

    void Update()
    {
       
        if (scoreText == null)
            BuscaScoreText();

        if (scoreText != null)
            scoreText.text = score.ToString();
    }
}