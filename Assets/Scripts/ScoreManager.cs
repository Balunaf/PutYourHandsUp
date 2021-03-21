using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text_score; //le texte pour afficher le score

    public int arret; //pour gérer le nombre de balles arrêtées

    public int total; //pour gérer le nombre de balles envoyées
    // Start is called before the first frame update
    void Start()
    {
        UpdateTotal();
    }

    // Update is called once per frame
    //on affiche le score du joueur ainsi qu'un petit texte en fonction de sa performance
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
    //pour calculer le nombre de balles envoyées
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
