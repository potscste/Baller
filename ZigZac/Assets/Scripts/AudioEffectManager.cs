using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffectManager : MonoBehaviour
{
    public static AudioEffectManager instance;
    public AudioSource coinAudio;
    public AudioSource gameOverAudio;

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

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayCoinAudio()
    {
        coinAudio.Play();
    }

    public void PlayGameOverAudio()
    {
        gameOverAudio.Play();
    }
}
