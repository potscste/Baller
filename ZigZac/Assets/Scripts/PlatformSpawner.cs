using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public GameObject diamond;
    Vector3 lastPostition;
    float size;
    // Start is called before the first frame update
    void Start()
    {
        lastPostition = platform.transform.position;
        size = platform.transform.localScale.x;

        for (int i = 0; i < 20; i++)
        {
            SpawnPlatforms();
        }

    }

    public void StartSpawningPlatforms()
    {
        InvokeRepeating("SpawnPlatforms", 2f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameOver == true)
        {
            CancelInvoke("SpawnPlatforms");
        }
    }

    void SpawnPlatforms()
    {
        int random = Random.Range(0, 6);
        if (random < 3)
        {
            SpawnX();
        }
        else
        {
            SpawnZ();
        }

    }

    void SpawnX()
    {
        Vector3 position = lastPostition;
        position.x += size;
        lastPostition = position;
        Instantiate(platform, position, Quaternion.identity);

        int random = Random.Range(0, 4);
        if (random < 1)
        {
            Instantiate(diamond, new Vector3(position.x, position.y + 1, position.z), diamond.transform.rotation);
        }
    }

    void SpawnZ()
    {
        Vector3 position = lastPostition;
        position.z += size;
        lastPostition = position;
        Instantiate(platform, position, Quaternion.identity);

        int random = Random.Range(0, 4);
        if (random < 1)
        {
            Instantiate(diamond, new Vector3(position.x, position.y + 1, position.z), diamond.transform.rotation);
        }
    }
}
