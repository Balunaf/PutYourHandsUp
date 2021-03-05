using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public float x;

    public float y;

    public float z = 20;

    private float xf;

    private float yf;

    private float zf;

    private bool stopped = false;

    private bool behind = false;

    private float time = 0;

    private float t = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnEnable()
    {
        zf = Random.Range(9f, 11f);
        yf = Random.Range(4f, 5f);
        xf = Random.Range(0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (stopped)
        {
            time += Time.deltaTime;
            z += 5 * Time.deltaTime;
            transform.position = new Vector3(x, y, z);
        }
        else
        {
            if (behind)
            {
                time += Time.deltaTime;
            }
            else
            {
                if (z > 0)
                {
                    t += Time.deltaTime;
                    z -= zf * Time.deltaTime;
                    y = -(5f * t * t)/2 + yf * t;
                    x += xf * Time.deltaTime;
                    transform.position = new Vector3(x, y, z);
                }
                else
                {
                    behind = true;
                }
            }  
        }
        if (time > 1)
        {
            time = 0;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            stopped = true;
        }
    }
}
