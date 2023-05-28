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
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    private int score;
    public bool isGameActive;
    private float spawnRate = 1.0f;
    void Start()
    {
        score = 0;
        isGameActive = true;
        
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        
    }

    
    void Update()
    {
        
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
    
    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void ResetartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
