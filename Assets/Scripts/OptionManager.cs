using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    [SerializeField] private Canvas menu;

    [SerializeField] private Text stats;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GameData data = SaveSystem.LoadData();
        stats.text = "Parties terminées : " + data.numberGames.ToString() + "\n"
            + "Temps de jeu : " + (data.timePlayed/60).ToString() + "h" + (data.timePlayed - 60*(data.timePlayed / 60)).ToString() + "\n"
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

    public void BackToMenu()
    {
        menu.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
