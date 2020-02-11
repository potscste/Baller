using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    public GameObject highScorePanel;
    public GameObject gameOverPanel;
    public GameObject tapText;


    public Text score;
    public Text highScore1;
    public Text highScore2;
    public Text actualScore;

    // Before Start
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        highScore1.text = "High Score: " + PlayerPrefs.GetInt("highScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }

    public void GameStart()
    {
        tapText.SetActive(false);
        highScorePanel.GetComponent<Animator>().Play("moveUp");
        actualScore.GetComponent<Animator>().Play("showDelay");
    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true);
        actualScore.text = "";
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("level1");
    }

    public void UpdateScore()
    {
        string score = ScoreManager.instance.score.ToString();
        if (score.Length < 4)
        {
            score = score.PadLeft(4, '0');
        }
        actualScore.text = score;
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

}
