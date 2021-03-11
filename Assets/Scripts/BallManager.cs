using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public float x;

    public float y;

    public float z = 20;

    private float yi;

    private float xf;

    private float yf;

    private float zf;

    private bool stopped = false;

    private bool behind = false;

    private float time = 0;

    private float t = 0;

    private Vector3 force;

    private float yn;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnEnable()
    {
        zf = Random.Range(9f, 11f);
        yf = Random.Range(3f, 4f);
        xf = Random.Range(-1f, 1f);
        force = new Vector3(xf, yf, zf);
        yi = y;
        while (!isGoodForce(force))
        {
            zf = Random.Range(9f, 11f);
            yf = Random.Range(3f, 4f);
            xf = Random.Range(-1f, 1f);
            force = new Vector3(xf, yf, zf);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stopped)
        {
            time += Time.deltaTime;
            t += Time.deltaTime;
            z += force.z * Time.deltaTime;
            y = yn -(3f * t * t) / 2 + force.y * t;
            x += force.x * Time.deltaTime;
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
                if (z > -2)
                {
                    t += Time.deltaTime;
                    z -= force.z * Time.deltaTime;
                    y = -(3f * t * t)/2 + force.y * t + yi;
                    x += force.x * Time.deltaTime;
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
            yn = transform.position.y;
            zf = Random.Range(2f, 3f);
            yf = Random.Range(1f, 2f);
            xf = Random.Range(-1f, 1f);
            force = new Vector3(xf, yf, zf);
            t = 0;
        }
    }

    bool isGoodForce(Vector3 f)
    {
        float tf = 19.3f / f.z;
        float xfinal = x + f.x * tf;
        float yfinal = y - (3 * tf * tf) / 2 + f.y * tf;
        bool right = LevelLoader.instance.rightHand;
        bool left = LevelLoader.instance.leftHand;
        if (yfinal > -0.3 && yfinal < 0.6)
        {
            if (right && xfinal > 0.25 && xfinal < 0.7)
            {
                return true;
            }
            if (left && xfinal > -0.7 && xfinal < -0.25)
            {
                return true;
            }
            if ((!right) && (!left) && xfinal > -0.75 && xfinal < 0.75)
            {
                return true;
            }
        }
        return false;
    }
}