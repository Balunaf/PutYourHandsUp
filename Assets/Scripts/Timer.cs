using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text timer;

    private float passedSecond;

    private int secondsRemaining;
    // Start is called before the first frame update
    void Start()
    {
        timer.text = "180s";
        secondsRemaining = 180;
    }

    // Update is called once per frame
    void Update()
    {
        passedSecond += Time.deltaTime;
        if (passedSecond > 1)
        {
            secondsRemaining -= 1;
            timer.text = secondsRemaining.ToString() + "s";
            passedSecond = 0;
        }
    }
}
