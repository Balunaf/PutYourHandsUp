using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    private float x;

    private float y;

    private float z = 20;

    private bool stopped = false;

    private float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(-8f, 8f);
        y = Random.Range(0f, 4f);
        transform.position = new Vector3(x, y, z);
    }

    // Update is called once per frame
    void Update()
    {
        if (stopped)
        {
            time += Time.deltaTime;
            Debug.Log(time);
        }
        else
        {
            if (z > 5)
            {
                z -= 10 * Time.deltaTime;
                transform.position = new Vector3(x, y, z);
            }
            else
            {
                stopped = true;
            }
        }
        if (time > 1)
        {
            Debug.Log("ok");
            time = 0;
            x = Random.Range(-8f, 8f);
            y = Random.Range(0f, 4f);
            z = 20;
            transform.position = new Vector3(x, y, z);
            stopped = false;
        }
    }
}
