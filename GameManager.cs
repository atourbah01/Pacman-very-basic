using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Ghost[] ghosts;
    public Pacman pacman;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;
    public bool gameIsOver = false;
    public int score { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        // Initialize the game
        NewGame();
    }

    private void NewGame()
    {
        // Set the score to zero
        SetScore(0);
        gameOverScreen.SetActive(false);
    }

    // Method to update the score and display it
    private void SetScore(int score)
    {
        this.score = score;
        scoreText.text = score.ToString();
    }

    // Method called when a pellet is eaten
    public void PelletEaten()
    {
        // Increase the score by 10 points for each pellet eaten
        SetScore(score + 10);
    }
    public void PowerPelletEaten(PowerPellet pellet)
    {
        score += 50; // Increase score by 50 when power pellet is eaten
        UpdateScore(); // Update the score display
        foreach (Ghost ghost in ghosts)
        {
            ghost.Frighten(); // Frighten all ghosts
        }
        Invoke(nameof(ResetGhostFrightened), pellet.duration); // Reset ghost frightened state after duration
    }
    public void GhostEaten(Ghost ghost)
    {
        score += 100; // Increase score by 100 when ghost is eaten
        UpdateScore(); // Update the score display
    }

    private void ResetGhostFrightened()
    {
        foreach (Ghost ghost in ghosts)
        {
            ghost.Calm(); // Reset all ghosts to their normal state
        }
    }
    public void PacmanEaten()
    {
        if (!gameIsOver)
        {
            gameIsOver = true;
            gameOverScreen.SetActive(true);// Activate the game over screen
            TextMeshProUGUI gameOverText = gameOverScreen.GetComponentInChildren<TextMeshProUGUI>();
            if (gameOverText != null)
            {
                gameOverText.text = "GAME OVER"; // Set the game over text
            }
            Destroy(pacman);
            // Optionally, disable player input or perform other game over actions
            pacman.GetComponent<Movement>().enabled = false;
        }
    }

    public void RestartGame()
    {
        // Reset game state, including score, lives, and positions of Pacman and ghosts
        score = 0;
        UpdateScore();
        gameIsOver = false;
        gameOverScreen.SetActive(false); // Deactivate the game over screen
        // Optionally, reset other game state variables and positions
    }

    private void UpdateScore()
    {
        scoreText.text = score.ToString(); // Update the score display
    }
}

