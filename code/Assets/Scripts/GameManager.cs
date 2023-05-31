using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI liveText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    public GameObject gameOverScreen;
    public GameObject pauseScreen;
    public AudioSource backgroundMusic;
    private int score;
    public int lives;
    public bool paused;
    public float savedVolume;
    public bool isGameActive;
    private float spawnRate = 1.0f;
    void Start()
    {

        
    }

    
    void Update()
    {   
        // Pause game when game is active and player press escape
        if(isGameActive)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                ChangePaused();
            }
  
        }
      
    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    
    public void UpdateLives(int losingLive)
    {
        lives += losingLive;
        liveText.text = "Lives: " + lives;
        if(lives <= 0)
        {
            GameOver();
        }
    }

    // Pause game and stop bgm without losing volume
    void ChangePaused()
    {
        
        if (!paused)
        {
            paused = true;
            pauseScreen.SetActive(true);
            savedVolume = AudioListener.volume;
            AudioListener.volume = 0;
            Time.timeScale = 0;
        }
        else
        {
            paused = false;
            pauseScreen.SetActive(false);
            AudioListener.volume = savedVolume;
            Time.timeScale = 1;

        }
    }
    
    public void GameOver()
    {
        gameOverScreen.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        AudioListener.volume = 0.39f;
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }

    public void StartGame(int difficulty)
    {
        score = 0;
        isGameActive = true;
        
        backgroundMusic = gameObject.GetComponent<AudioSource>();
        
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        UpdateLives(3);
        spawnRate /= difficulty;
        titleScreen.gameObject.SetActive(false);
    }
}
