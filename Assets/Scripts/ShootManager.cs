using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    [SerializeField] private BallManager originalBall = null; //pour connaître la balle à instancier

    [SerializeField] private ScoreManager score; //pour gérer le score

    [SerializeField] private AudioManager audioManager; //pour gérer le son

    public LineRenderer lineRenderer; //pour gérer le pop-up de fin

    public Canvas canvas; //pour gérer le pop-up de fin

    private float time = 0; //pour gérer le temps

    private float totalTime = 0;

    private float x;

    private float y;

    private float z = 21;
    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(-1f, 1f);
        y = Random.Range(-0.5f, 0.5f);
        transform.position = new Vector3(x, y, z);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        totalTime += Time.deltaTime;
        if (totalTime > 20)
        {
            canvas.gameObject.SetActive(true);
            lineRenderer.gameObject.SetActive(true);
        }
        if (totalTime < 18)
        {
            if (time > 8 && LevelLoader.instance.difficulte == 1)
            {
                NewBall();
                time = 0;
            }
            if (time > 6 && LevelLoader.instance.difficulte == 2)
            {
                NewBall();
                time = 0;
            }
            if (time > 5 && LevelLoader.instance.difficulte == 3)
            {
                NewBall();
                time = 0;
            }
        } 
    }

    private void NewBall()
    {
        audioManager.SendBall();
        x = Random.Range(-0.5f, 0.5f);
        y = Random.Range(0f, 1f);
        transform.position = new Vector3(x, y, z);
        var newBall = Instantiate(originalBall, transform.position, transform.rotation);
        newBall.x = x;
        newBall.y = y;
        newBall.z = z - 1;
        newBall.gameObject.SetActive(true);
    }
}
