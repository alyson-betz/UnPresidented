using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public float TimePerLevel = 10; 
    public float levelTime;
    public int level;
    public int playerScore;
    public GameObject GameOverScreen;
    public int EnemyMax;
    public bool paused = false;

    public void Start()
    {
        //level = 1;
        Time.timeScale = 0;
        InitLevel();
    }

    public void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown("r"))
        {
            restartGame();
        }
        levelTime -= Time.deltaTime;
        if (levelTime <= 0)
        {
            LevelWin();
        }
    }

    public void addScore(int scoreToAdd)
    { 
        playerScore += scoreToAdd;
    }

    public void InitLevel()
    {
        EnemyMax = 5 * level;
        levelTime = TimePerLevel * level;
        var screens = GameObject.FindGameObjectsWithTag("Screen");
        foreach (var s in screens)
        {
            s.gameObject.SetActive(false);
        }
    }

    public void gameOver()
    {
        paused = true;
        Time.timeScale = 0;
        GameOverScreen.SetActive(true);
    }

    public void LevelWin()
    {
        level++;
        InitLevel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);// ????? this might not work lmao
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        
    }
}
