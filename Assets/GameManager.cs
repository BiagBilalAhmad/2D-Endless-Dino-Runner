using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public bool StartGame = false;
    [Header("Ingame Data")]
    public TMP_Text ScoreTxt;
    public int score;

    [Header("GameOver Data")]
    public TMP_Text finalScoreTxt;
    public TMP_InputField nameInput;

    [Header("Panels")]
    public GameObject mainMenuPanel;
    public GameObject gameOverPanel;
    public GameObject leaderboardPanel;

    private void Start()
    {
        Time.timeScale = 1f;

        mainMenuPanel.SetActive(true);
        leaderboardPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void PlayGame()
    {
        StartGame = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowGameOver()
    {
        Time.timeScale = 0f;
        finalScoreTxt.text = score.ToString();
        gameOverPanel.SetActive(true);
    }

    public void AddToLeaderBoard()
    {
        if(nameInput.text.Length > 0)
        {
            HighScoreManager.Instance.AddHighScoreEntry(nameInput.text, score);
        }
    }

    public void ShowLeaderboard()
    {
        HighScoreManager.Instance.LoadHighScores();
        leaderboardPanel.SetActive(true);
    }

    public void UpdateScore()
    {
        score++;
        ScoreTxt.text = "Score : " + score;
    }
}
