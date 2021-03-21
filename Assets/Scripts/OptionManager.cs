﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    [SerializeField] private Canvas menu; //le menu des options

    [SerializeField] private TextMeshProUGUI stats; //le text des statistiques du jeu 1
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
        if (data.timePlayed - 60 * (data.timePlayed / 60) < 10)
        {
            stats.text = "Parties terminées : " + data.numberGames.ToString() + "\n"
            + "Temps de jeu : " + (data.timePlayed / 60).ToString() + "h0" + (data.timePlayed - 60 * (data.timePlayed / 60)).ToString() + "\n"
            + "Meilleur score facile : " + data.highScoreEasy.ToString() + "\n"
            + "Meilleur score moyen : " + data.highScoreMedium.ToString() + "\n"
            + "Meilleur score difficle : " + data.highScoreDifficult.ToString() + "\n"
            + "Meilleur score main droite facile : " + data.highScoreEasyRight.ToString() + "\n"
            + "Meilleur score main droite moyen : " + data.highScoreMediumRight.ToString() + "\n"
            + "Meilleur score main droite difficile : " + data.highScoreDifficultRight.ToString() + "\n"
            + "Meilleur score main gauche facile : " + data.highScoreEasyLeft.ToString() + "\n"
            + "Meilleur score main gauche moyen : " + data.highScoreMediumLeft.ToString() + "\n"
            + "Meilleur score main gauche difficile : " + data.highScoreDifficultLeft.ToString();
        }
        else
        {
            stats.text = "Parties terminées : " + data.numberGames.ToString() + "\n"
            + "Temps de jeu : " + (data.timePlayed / 60).ToString() + "h" + (data.timePlayed - 60 * (data.timePlayed / 60)).ToString() + "\n"
            + "Meilleur score facile : " + data.highScoreEasy.ToString() + "\n"
            + "Meilleur score moyen : " + data.highScoreMedium.ToString() + "\n"
            + "Meilleur score difficle : " + data.highScoreDifficult.ToString() + "\n"
            + "Meilleur score main droite facile : " + data.highScoreEasyRight.ToString() + "\n"
            + "Meilleur score main droite moyen : " + data.highScoreMediumRight.ToString() + "\n"
            + "Meilleur score main droite difficile : " + data.highScoreDifficultRight.ToString() + "\n"
            + "Meilleur score main gauche facile : " + data.highScoreEasyLeft.ToString() + "\n"
            + "Meilleur score main gauche moyen : " + data.highScoreMediumLeft.ToString() + "\n"
            + "Meilleur score main gauche difficile : " + data.highScoreDifficultLeft.ToString();
        }  
    }
    //la fonction à appeler pour revenir au menu des options
    public void BackToMenu()
    {
        menu.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
