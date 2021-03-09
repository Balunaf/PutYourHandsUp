using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text text_score;

    public float arret;

    public int total;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (arret < 5)
        {
            text_score.text = "C'est un bon début !\n" + arret.ToString() + " / " + total.ToString();
        }
        else
        {
            if (arret < 10)
            {
                text_score.text = "Pas mal !\n" + arret.ToString() + " / " + total.ToString();
            }
            else
            {
                if(arret < 15)
                {
                    text_score.text = "Bien !\n" + arret.ToString() + " / " + total.ToString();
                }
                else
                {
                    text_score.text = "Excellent !\n" + arret.ToString() + " / " + total.ToString();
                }
            }
        }
    }
}
