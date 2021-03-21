using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text timer; //le texte pour afficher le temps

    private float passedSecond; //pour gérer l'écoulement d'une seconde

    private int secondsRemaining; //pour gérer le temps restant
    // Start is called before the first frame update
    void Start()
    {
        timer.text = "180s";
        secondsRemaining = 180;
    }

    // Update is called once per frame
    //à chaque seconde passé, on décrémente le temps restant de 1
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
