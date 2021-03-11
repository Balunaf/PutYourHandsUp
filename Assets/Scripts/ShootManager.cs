using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    [SerializeField] private BallManager originalBall = null;

    [SerializeField] private float rateOfFire = 1;

    [SerializeField] private ScoreManager score;

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
            if (time > 3)
            {
                score.total += 1;
                x = Random.Range(-0.5f, 0.5f);
                y = Random.Range(0f, 1f);
                transform.position = new Vector3(x, y, z);
                var newBall = Instantiate(originalBall, transform.position, transform.rotation);
                newBall.x = x;
                newBall.y = y;
                newBall.z = z - 1;
                newBall.gameObject.SetActive(true);
                time = 0;
            }
        } 
    }
}
