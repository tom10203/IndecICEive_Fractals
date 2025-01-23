using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score, lives;


    public bool isGameOver;
    public UnityEvent gameOver;

    [Header("User Interface Elements")]
    public GameObject gameOverScreen;
    public GameObject HUD, newHighscoreText;
    public TMP_Text scoreText, livesText, scoreTextGameOver, highscoreText;



    public void updateUI(int scoreChange, int livesChanged)
    {
        score += scoreChange;
        lives += livesChanged;
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;

        if (lives <= 0)
        {
            gameOverState();
        }
    }


    public void gameOverState()
    {
        MBSBoundayLimits[] mbsbl = FindObjectsByType<MBSBoundayLimits>(FindObjectsSortMode.None);

        for (int i = 0; i < mbsbl.Length; i++)
        {
            mbsbl[i].isGameOver = true;
        }

        gameOver.Invoke();
        scoreTextGameOver.text = "SCORE : " + score;
        highscoreText.text = "HIGHSCORE : " + PlayerPrefs.GetInt("Highscore");
        isGameOver = true;
        HUD.SetActive(false);
        gameOverScreen.SetActive(true);

        //Time.timeScale = 0;

    }

    public void restartLevel()
    {
        //Load main menu & gameover screen
        Debug.Log("Restart Button Clicked");
        SceneManager.LoadScene(0);
    
    }

    






}
