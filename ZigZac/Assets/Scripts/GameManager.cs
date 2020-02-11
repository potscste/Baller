using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameOver;

    public AudioManager audioManager;

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
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameStart()
    {
        UiManager.instance.GameStart();
        ScoreManager.instance.StartScore();
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().StartSpawningPlatforms();
    }

    public void GameOver()
    {
        if (!gameOver)
        {
            ScoreManager.instance.StopScore();
            AudioEffectManager.instance.PlayGameOverAudio();
            audioManager.gameMusic.Stop();
            UiManager.instance.GameOver();
            gameOver = true;
            UnityAddManager.instance.ShowAd();
        }
    }
}
