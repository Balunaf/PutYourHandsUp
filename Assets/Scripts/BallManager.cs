using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] MeshRenderer mesh;

    private float x;

    private float y;

    private float z = 20;

    private bool stopped = false;

    private float time = 0;

    private float totalTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(-8f, 8f);
        y = Random.Range(0f, 3f);
        transform.position = new Vector3(x, y, z);
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
            if (z > 0)
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
            time = 0;
            x = Random.Range(-8f, 8f);
            y = Random.Range(0f, 3f);
            z = 20;
            transform.position = new Vector3(x, y, z);
            stopped = false;
        }
        totalTime += Time.deltaTime;
        if (totalTime > 180)
        {
            stopped = true;
            time = 0;
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
