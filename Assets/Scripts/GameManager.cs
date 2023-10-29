using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Attributes
    public static GameManager instance;

    [Header("Platform Spawn")]
    public bool gameStarted;
    [SerializeField] GameObject platformSpawner;

    [Header("Game UI")]
    [SerializeField] GameObject gamePlayUI;
    [SerializeField] GameObject menuUI;

    [Header("End game UI")]
    [SerializeField] GameObject endGameUI;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI finalScoreText;
    [SerializeField] TextMeshProUGUI highestScoreText;

    public int score = 0;
    int highScore;

    // Singleton
    private void Awake()
    {
        MakeInstance();
    }

    private void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        MenuStart();
    }

    private void MenuStart()
    {
        // Gan diem high score gan nhat co dc
        menuUI.SetActive(true);
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "BEST SCORE: " + highScore;
        endGameUI.SetActive(false);

        SoundManager.Instance.PlayMusic(SoundManager.Instance.menuSound);
    }

    void Update()
    {
        TriggerFirstTouch();
    }

    private void TriggerFirstTouch()
    {
        if (!gameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameStart();
            }
        }
    }

    public void GameStart()
    {

        gameStarted = true;
        platformSpawner.SetActive(true);

        menuUI.SetActive(false);
        gamePlayUI.SetActive(true);
        endGameUI.SetActive(false);

        SoundManager.Instance.PlayMusic(SoundManager.Instance.gamePlaySound);
        StartCoroutine("UpdateScore");
    }


    public void GameOver()
    {
        platformSpawner.SetActive(false);
        StopCoroutine("UpdateScore");
        SaveHighScore();
        gamePlayUI.SetActive(false);
        Invoke("ShowEndGameUI", 0.8f);
    }

    void ShowEndGameUI()
    {
        SoundManager.Instance.musicSource.Stop();
        highestScoreText.text = "Highest Score: " + highScore;
        finalScoreText.text = "Your score: " + score;
        endGameUI.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    // Xai coroutine de them diem theo time
    // Wait 1 second thi score ++;
    IEnumerator UpdateScore()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            score++;
            scoreText.text = score.ToString();
        }
    }


    // 1 diamonds = 2 points
    public void IncrementScore(int point)
    {
        score += point;
        scoreText.text = score.ToString();
        SoundManager.Instance.PlaySFXMusic(SoundManager.Instance.pickUpCoinSound, 0.3f);
    }

    private void SaveHighScore()
    {
        // Already had a high score
        if(PlayerPrefs.HasKey("HighScore"))
        {
            if(score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
        else
        {
            // Playing for the first time
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}

