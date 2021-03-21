using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Option2Manager : MonoBehaviour
{
    [SerializeField] private Canvas menu; //le menu des options

    [SerializeField] private TextMeshProUGUI stats; //le text des statistiques du jeu 2
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //on affiche les statistiques du jeu, avec x h 0y si y<10 minutes et x h y sinon
        GameData data = SaveSystem.LoadData();
        if (data.timePlayed2 - 60 * (data.timePlayed2 / 60) < 10)
        {
            stats.text = "Parties terminées : " + data.numberGames2.ToString() + "\n"
            + "Temps de jeu : " + (data.timePlayed2 / 60).ToString() + "h0" + (data.timePlayed2 - 60 * (data.timePlayed2 / 60)).ToString() + "\n"
            + "Meilleur score main droite facile : " + data.highScoreEasyRight2.ToString() + "\n"
            + "Meilleur score main droite moyen : " + data.highScoreMediumRight2.ToString() + "\n"
            + "Meilleur score main droite difficile : " + data.highScoreDifficultRight2.ToString() + "\n"
            + "Meilleur score main gauche facile : " + data.highScoreEasyLeft2.ToString() + "\n"
            + "Meilleur score main gauche moyen : " + data.highScoreMediumLeft2.ToString() + "\n"
            + "Meilleur score main gauche difficile : " + data.highScoreDifficultLeft2.ToString();
        }
        else
        {
            stats.text = "Parties terminées : " + data.numberGames2.ToString() + "\n"
            + "Temps de jeu : " + (data.timePlayed2 / 60).ToString() + "h" + (data.timePlayed2 - 60 * (data.timePlayed2 / 60)).ToString() + "\n"
            + "Meilleur score main droite facile : " + data.highScoreEasyRight2.ToString() + "\n"
            + "Meilleur score main droite moyen : " + data.highScoreMediumRight2.ToString() + "\n"
            + "Meilleur score main droite difficile : " + data.highScoreDifficultRight2.ToString() + "\n"
            + "Meilleur score main gauche facile : " + data.highScoreEasyLeft2.ToString() + "\n"
            + "Meilleur score main gauche moyen : " + data.highScoreMediumLeft2.ToString() + "\n"
            + "Meilleur score main gauche difficile : " + data.highScoreDifficultLeft2.ToString();
        }
    }
    //la fonction à appeler pour revenir au menu des options
    public void BackToMenu()
    {
        menu.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
