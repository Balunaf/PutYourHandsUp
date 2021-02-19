using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 1)
        {
            gameObject.SetActive(true);
        }
        if (time > 2)
        {
            gameObject.SetActive(false);
            time = 0;
        }
    }
}
