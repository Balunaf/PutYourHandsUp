using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int numberGames; //le nombres de parties jouées dans le jeu 1
    public int timePlayed; //le temps passé à jouer dans le jeu 1
    public int highScoreEasy; //le meilleur score dans le jeu 1 facile
    public int highScoreMedium; //le meilleur score dans le jeu 1 moyen
    public int highScoreDifficult; //le meilleur score dans le jeu 1 difficile
    public int highScoreEasyRight; //le meilleur score dans le jeu 1 main droite facile
    public int highScoreMediumRight; //le meilleur score dans le jeu 1 main droite moyen
    public int highScoreDifficultRight; //le meilleur score dans le jeu 1 main droite difficile
    public int highScoreEasyLeft; //le meilleur score dans le jeu 1 main gauche facile
    public int highScoreMediumLeft; //le meilleur score dans le jeu 1 main gauche moyen
    public int highScoreDifficultLeft; //le meilleur score dans le jeu 1 main gauche difficile
    public int numberGames2; //le nombres de parties jouées dans le jeu 2
    public int timePlayed2; //le temps passé à jouer dans le jeu 2
    public int highScoreEasy2; //le meilleur score dans le jeu 2 facile
    public int highScoreMedium2; //le meilleur score dans le jeu 2 moyen
    public int highScoreDifficult2; //le meilleur score dans le jeu 2 difficile
    public int highScoreEasyRight2; //le meilleur score dans le jeu 2 main droite facile
    public int highScoreMediumRight2; //le meilleur score dans le jeu 2 main droite moyen
    public int highScoreDifficultRight2; //le meilleur score dans le jeu 2 main droite difficile
    public int highScoreEasyLeft2; //le meilleur score dans le jeu 2 main gauche facile
    public int highScoreMediumLeft2; //le meilleur score dans le jeu 2 main gauche moyen
    public int highScoreDifficultLeft2; //le meilleur score dans le jeu 2 main gauche difficile

    //constructeur d'un GameData
    public GameData(int _number, int _time, int _highe, int _highm, int _highd, int _higher,
        int _highmr, int _highdr, int _highel, int _highml, int _highdl,
        int _number2, int _time2, int _highe2, int _highm2, int _highd2, int _higher2,
        int _highmr2, int _highdr2, int _highel2, int _highml2, int _highdl2)
    {
        numberGames = _number;
        timePlayed = _time;
        highScoreEasy = _highe;
        highScoreMedium = _highm;
        highScoreDifficult = _highd;
        highScoreEasyRight = _higher;
        highScoreMediumRight = _highmr;
        highScoreDifficultRight = _highdr;
        highScoreEasyLeft = _highel;
        highScoreMediumLeft = _highml;
        highScoreDifficultLeft = _highdl;
        numberGames2 = _number2;
        timePlayed2 = _time2;
        highScoreEasy2 = _highe2;
        highScoreMedium2 = _highm2;
        highScoreDifficult2 = _highd2;
        highScoreEasyRight2 = _higher2;
        highScoreMediumRight2 = _highmr2;
        highScoreDifficultRight2 = _highdr2;
        highScoreEasyLeft2 = _highel2;
        highScoreMediumLeft2 = _highml2;
        highScoreDifficultLeft2 = _highdl2;
    }
}
