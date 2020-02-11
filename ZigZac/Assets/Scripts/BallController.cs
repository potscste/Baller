using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject particle;

    public float speed;
    bool started;
    bool gameOver;

    private int diamondScore = 3;

    Rigidbody Rigidbody;

    void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        started = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Rigidbody.velocity = new Vector3(speed, 0, 0);
                started = true;

                GameManager.instance.GameStart();
            }
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        // Game Over
        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
            Rigidbody.velocity = new Vector3(0, -25, 0);
            Camera.main.GetComponent<CameraFollow>().gameOver = true;
            GameManager.instance.GameOver();
        }

        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwitchDirection();
        }

    }


    void SwitchDirection()
    {
        if (Rigidbody.velocity.z > 0)
        {

            Rigidbody.velocity = new Vector3(speed, 0, 0);

        }
        else if (Rigidbody.velocity.x > 0)
        {

            Rigidbody.velocity = new Vector3(0, 0, speed);

        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Diamond")
        {
            GameObject part = Instantiate(particle, collider.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(collider.gameObject);
            Destroy(part, 1f);
            ScoreManager.instance.IncreaseScore(diamondScore);
            AudioEffectManager.instance.PlayCoinAudio();
        }
    }
}
