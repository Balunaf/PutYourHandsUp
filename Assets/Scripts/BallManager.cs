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

    //Sound variables
    [SerializeField] private AudioSource sourcePassed;

    [SerializeField] private AudioClip passed;

    private bool played;

    // Start is called before the first frame update
    void Start()
    {
        played = false;
    }

    private void OnEnable()
    {
        zf = Random.Range(9f, 11f);
        yf = Random.Range(2f, 4f);
        xf = Random.Range(-1f, 1f);
        force = new Vector3(xf, yf, zf);
        yi = y;
        while (!isGoodForce(force))
        {
            zf = Random.Range(9f, 11f);
            yf = Random.Range(2f, 4f);
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
            if (z < 1.4 && !played)
            {
                PassedBall();
            }
        }
        if (time > 1 && LevelLoader.instance.game1)
        {
            time = 0;
            Destroy(gameObject);
        }
        if (time > 2 && LevelLoader.instance.game2)
        {
            time = 0;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand") && LevelLoader.instance.game1)
        {
            stopped = true;
            yn = transform.position.y;
            zf = Random.Range(2f, 3f);
            yf = Random.Range(1f, 2f);
            xf = Random.Range(-1f, 1f);
            force = new Vector3(xf, yf, zf);
            t = 0;
        }
        if (other.CompareTag("Racket") && LevelLoader.instance.game2)
        {
            stopped = true;
            yn = transform.position.y;
            zf = Random.Range(9f, 11f);
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
        if (LevelLoader.instance.difficulte == 1 && yfinal > -0.3f && yfinal < 0.4f)
        {
            if (right && xfinal > 0 && xfinal < 0.4f)
            {
                return true;
            }
            if (left && xfinal > -0.4f && xfinal < 0)
            {
                return true;
            }
            if ((!right) && (!left) && xfinal > -0.4f && xfinal < 0.4f)
            {
                return true;
            }
        }
        if (LevelLoader.instance.difficulte == 2 && yfinal > 0 && yfinal < 0.5f)
        {
            if (right && xfinal > 0.1f && xfinal < 0.5f)
            {
                return true;
            }
            if (left && xfinal > -0.5f && xfinal < -0.1f)
            {
                return true;
            }
            if ((!right) && (!left) && ((xfinal > -0.5f && xfinal < -0.1f) || (xfinal > 0.1f && xfinal < 0.5f)))
            {
                return true;
            }
        }
        if (LevelLoader.instance.difficulte == 3 && yfinal > 0.3f && yfinal < 0.6f)
        {
            if (right && xfinal > 0.2f && xfinal < 0.6f)
            {
                return true;
            }
            if (left && xfinal > -0.6f && xfinal < -0.2f)
            {
                return true;
            }
            if ((!right) && (!left) && ((xfinal > -0.6f && xfinal < -0.2f) || (xfinal > 0.2f && xfinal < 0.6f)))
            {
                return true;
            }
        }
        return false;
    }
    private void PassedBall()
    {
        sourcePassed.loop = false;
        sourcePassed.PlayOneShot(passed);
        played = true;
    }
}