using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public float x;

    public float y;

    public float z = 20;

    private bool stopped = false;

    private bool behind = false;

    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnEnable()
    {
        //calcul de la force
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
                    z -= 10 * Time.deltaTime;
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
