using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScorePlayerManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public int score = 100;

    //public static ScorePlayerManager Instance { get; private set; }

    /*
    private void Awake()
    {
        // Ensure there is only one instance of the ScoreManager.
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Prevent the object from being destroyed between scenes.
        }
        else
        {
            Destroy(gameObject); // If an instance already exists, destroy this one.
        }
    }
    */

    private void Start()
    {
        // Initialize the score text.
        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        // Add points to the score.
        score += points;

        // Update the score text.
        UpdateScoreText();
    }

    public void RemoveScore(int points)
    {
        // Remove points from the score.
        score -= points;

        // Ensure the score doesn't go below zero.
        score = Mathf.Max(score, 0);

        // Update the score text.
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        // Update the UI TextMeshPro field with the current score.
        scoreText.text = "Score: " + score.ToString();
    }
}
