using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int numberGames;
    public int timePlayed;
    public int highScoreEasy;
    public int highScoreMedium;
    public int highScoreDifficult;
    public int highScoreEasyRight;
    public int highScoreMediumRight;
    public int highScoreDifficultRight;
    public int highScoreEasyLeft;
    public int highScoreMediumLeft;
    public int highScoreDifficultLeft;
    public int numberGames2;
    public int timePlayed2;
    public int highScoreEasy2;
    public int highScoreMedium2;
    public int highScoreDifficult2;
    public int highScoreEasyRight2;
    public int highScoreMediumRight2;
    public int highScoreDifficultRight2;
    public int highScoreEasyLeft2;
    public int highScoreMediumLeft2;
    public int highScoreDifficultLeft2;

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
