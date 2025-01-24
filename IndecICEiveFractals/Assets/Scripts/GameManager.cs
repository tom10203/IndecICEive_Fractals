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

    private int highscore;

    private void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore", 0); 
    }

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
        if (score > highscore)
        {
            highscore = score; 
            PlayerPrefs.SetInt("Highscore", highscore);
            PlayerPrefs.Save(); 
        }
   

        MBSBoundayLimits[] mbsbl = FindObjectsByType<MBSBoundayLimits>(FindObjectsSortMode.None);

        for (int i = 0; i < mbsbl.Length; i++)
        {
            mbsbl[i].isGameOver = true;
        }

        gameOver.Invoke();
        scoreTextGameOver.text = "SCORE : " + score;
        highscoreText.text = "HIGHSCORE : " + highscore; 

        isGameOver = true;
        HUD.SetActive(false);
        gameOverScreen.SetActive(true);

        Time.timeScale = 0;
        Cursor.visible = true;
    }

    public void restartLevel()
    {
        Time.timeScale = 1;
        Destroy(DifficultySlider.instance.gameObject);
        SceneManager.LoadScene(0);
    }
}
