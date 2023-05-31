using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiffucltyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public int difficulty;
   
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {


    }




    void SetDifficulty()
    {
        Debug.Log(gameObject.name + " was clicked");
        gameManager.StartGame(difficulty);
        
    }
}

/* 

void ChangePaused()
{
    if (!paused)
    {
        paused = true;
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }
    else
    {
        paused = false;
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }
}


 */
