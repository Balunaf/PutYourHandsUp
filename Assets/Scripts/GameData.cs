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

    public GameData(int _number, int _time, int _highe, int _highm, int _highd, int _higher, int _highmr, int _highdr, int _highel, int _highml, int _highdl)
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
    }
}
