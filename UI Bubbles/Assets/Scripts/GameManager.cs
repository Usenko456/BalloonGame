using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI")]
    public TMP_Text scoreText;
    public GameObject restartMenu;

    private int score = 0;
    private float levelDuration = 31f;
    private const string CoinsKey = "PlayerCoins";

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateUI();
        if (restartMenu != null)
            restartMenu.SetActive(false);

        Invoke(nameof(EndLevel), levelDuration);
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "SCORE: " + score;
    }

    void EndLevel()
    {
        int reward = Mathf.FloorToInt(score / 5f); 
        int currentBalance = PlayerPrefs.GetInt(CoinsKey, 200); 
        int newBalance = currentBalance + reward;

        PlayerPrefs.SetInt(CoinsKey, newBalance); 
        PlayerPrefs.Save();

        if (restartMenu != null)
            restartMenu.SetActive(true);

        Time.timeScale = 0f;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
