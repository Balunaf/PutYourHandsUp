using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text text_score;

    public int arret;

    public int total;
    // Start is called before the first frame update
    void Start()
    {
        UpdateTotal();
    }

    // Update is called once per frame
    void Update()
    {
        if (arret < total/4)
        {
            text_score.text = "C'est un bon début !\n" + arret.ToString() + " / " + total.ToString();
        }
        else
        {
            if (arret < total/2)
            {
                text_score.text = "Pas mal !\n" + arret.ToString() + " / " + total.ToString();
            }
            else
            {
                if(arret < (3*total)/4)
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

    private void UpdateTotal()
    {
        int dif = LevelLoader.instance.difficulte;
        if (dif == 1)
        {
            total = 22;
        }
        if (dif == 2)
        {
            total = 29;
        }
        if (dif == 3)
        {
            total = 35;
        }
    }
}
