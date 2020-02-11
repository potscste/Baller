using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAddManager : MonoBehaviour
{
    public static UnityAddManager instance;

    private void Awake()
    {

        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
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

    public void ShowAd()
    {
        if (PlayerPrefs.HasKey("adcount"))
        {
            if (PlayerPrefs.GetInt("adcount") == 3)
            {
                if (Advertisement.IsReady("video"))
                {
                    Advertisement.Show("video");
                }
                PlayerPrefs.SetInt("adcount", 0);
            }
            else
            {
                int adcount = PlayerPrefs.GetInt("adcount");
                PlayerPrefs.SetInt("adcount", adcount + 1);
            }
        }
        else
        {
            PlayerPrefs.SetInt("adcount", 1);
        }


    }
}
