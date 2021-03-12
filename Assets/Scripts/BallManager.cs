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
        int dif = LevelLoader.instance.difficulte;
        if (dif == 1)
        {
            if (yfinal > -0.3 && yfinal < 0.4)
            {
                if (right && xfinal > 0 && xfinal < 0.4)
                {
                    return true;
                }
                if (left && xfinal > -0.4 && xfinal < 0)
                {
                    return true;
                }
                if ((!right) && (!left) && xfinal > -0.4 && xfinal < 0.4)
                {
                    return true;
                }
            }
        }
        if (dif == 2)
        {
            if (yfinal > 0 && yfinal < 0.5)
            {
                if (right && xfinal > 0.1 && xfinal < 0.5)
                {
                    return true;
                }
                if (left && xfinal > -0.5 && xfinal < -0.1)
                {
                    return true;
                }
                if ((!right) && (!left) && ((xfinal > -0.5 && xfinal < -0.1) || (xfinal > 0.1 && xfinal < 0.5)))
                {
                    return true;
                }
            }
        }
        if (dif == 3)
        {
            if (yfinal > 0.3 && yfinal < 0.6)
            {
                if (right && xfinal > 0.2 && xfinal < 0.6)
                {
                    return true;
                }
                if (left && xfinal > -0.6 && xfinal < -0.2)
                {
                    return true;
                }
                if ((!right) && (!left) && ((xfinal > -0.6 && xfinal < -0.2) || (xfinal > 0.2 && xfinal < 0.6)))
                {
                    return true;
                }
            }
        }
        return false;
    }
}