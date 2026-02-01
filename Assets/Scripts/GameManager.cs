using UnityEngine;
using TMPro;            
using UnityEngine.SceneManagement; 
using UnityEngine.UI;   

public class GameManager : MonoBehaviour
{
    //Game Settings
    public int score = 0;
    public int winScore = 10;
    public float gameTime = 60.0f;
    public bool isGamePaused = false;

    //UI Connections
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI timerText;

    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject pausePanel;

    //Settings Menu
    public GameObject settingsPanel;
    public Slider volumeSlider;

    private bool isGameOver = false;
    private PlayerController player;

    void Start()
    {
        
        Time.timeScale = 1f;
        
        if (winPanel != null) winPanel.SetActive(false);
        if (losePanel != null) losePanel.SetActive(false);
        if (pausePanel != null) pausePanel.SetActive(false);
        if (settingsPanel != null) settingsPanel.SetActive(false);

        
        if (volumeSlider != null)
        {
            volumeSlider.value = AudioListener.volume;
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }

        // find total collectibles
        winScore = Object.FindObjectsByType<Collectibles>(FindObjectsSortMode.None).Length;

        // update score table
        if (scoreText != null) scoreText.text = "Score: " + score;

        // Find player and show health
        player = Object.FindFirstObjectByType<PlayerController>();
        if (player != null && healthText != null)
        {
            healthText.text = "Health: " + player.health;
        }
    }

    void Update()
    {
        // Attach Escape button
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused) ResumeGame();
            else PauseGame();
        }

        // Keep timer on
        if (!isGameOver && !isGamePaused)
        {
            if (gameTime > 0)
            {
                gameTime -= Time.deltaTime;
                if (timerText != null)
                {
                    timerText.text = "Time: " + Mathf.CeilToInt(gameTime).ToString();
                }
            }
            else
            {
                gameTime = 0;
                GameOver(); 
            }
        }
    }

    // Pause Menu

    public void PauseGame()
    {
        isGamePaused = true;
        if (pausePanel != null) pausePanel.SetActive(true);
        Time.timeScale = 0f; // Pause Time
    }

    public void ResumeGame()
    {
        isGamePaused = false;
        if (pausePanel != null) pausePanel.SetActive(false);
        if (settingsPanel != null) settingsPanel.SetActive(false);
        Time.timeScale = 1f; // Resume Time
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0); 
    }

    public void OpenSettings()
    {
        if (pausePanel != null) pausePanel.SetActive(false);
        if (settingsPanel != null) settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        if (settingsPanel != null) settingsPanel.SetActive(false);
        if (pausePanel != null) pausePanel.SetActive(true);
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    // Game Logic

    public void AddScore(int amount)
    {
        if (isGameOver) return;

        score += amount;
        Debug.Log("New Score: " + score); 

        if (scoreText != null) scoreText.text = "Score: " + score;

        if (score >= winScore)
        {
            WinGame();
        }
    }

    public void UpdateHealth(int currentHealth)
    {
        if (healthText != null) healthText.text = "Health: " + currentHealth;
    }

    public void WinGame()
    {
        isGameOver = true;
        Debug.Log("YOU WIN. Congrats."); 

        if (winPanel != null) winPanel.SetActive(true);

        if (player != null)
        {
            
            if (Camera.main != null)
            {
                Camera.main.transform.parent = null;
            }

            player.gameObject.SetActive(false);
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("YOU LOSE. Game Over."); 

        if (losePanel != null) losePanel.SetActive(true);

        if (player != null)
        {
            
            if (Camera.main != null)
            {
                Camera.main.transform.parent = null;
            }
            player.gameObject.SetActive(false);
        }
    }
}