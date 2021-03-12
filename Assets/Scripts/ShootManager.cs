using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    [SerializeField] private BallManager originalBall = null;

    [SerializeField] private float rateOfFire = 1;

    [SerializeField] private ScoreManager score;

    [SerializeField] private AudioManager audio;

    public LineRenderer lineRenderer;

    public Canvas canvas;

    private float time = 0;

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
        NewBall();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        totalTime += Time.deltaTime;
        if (totalTime > 20)
        {
            //faire le pop up
            canvas.gameObject.SetActive(true);
            lineRenderer.gameObject.SetActive(true);
        }
        else
        {
            if (LevelLoader.instance.difficulte == 1 && time > 8)
            {
                NewBall();
                time = 0;
            }
            if (LevelLoader.instance.difficulte == 2 && time > 6)
            {
                NewBall();
                time = 0;
            }
            if (LevelLoader.instance.difficulte == 3 && time > 5)
            {
                NewBall();
                time = 0;
            }
        } 
    }

    private void NewBall()
    {
        audio.SendBall();
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
