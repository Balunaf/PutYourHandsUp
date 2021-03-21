using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuLoader : MonoBehaviour
{
    [SerializeField] private Canvas canvas; //le pop-up de fin de partie

    [SerializeField] ScoreManager score; //le score
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //la fonction à appeler pour retourner au menu
    public void LoadLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    //on desactive le pop-up pendant la partie
    private void OnEnable()
    {
        canvas.gameObject.SetActive(false);
    }
    //la fonction à appeler pour sauvegarder les données
    public void SaveData()
    {
        int currentScore = score.arret;
        GameData data = SaveSystem.LoadData();
        if (LevelLoader.instance.game1)
        {
            int gamesPlayed = data.numberGames + 1;
            int newTimePlayed = data.timePlayed + 3;
            if (LevelLoader.instance.rightHand)
            {
                if (LevelLoader.instance.difficulte == 1)
                {
                    int maxScore = data.highScoreEasyRight;
                    int newMaxScore = maxScore;
                    if (currentScore > maxScore)
                    {
                        newMaxScore = currentScore;
                    }
                    SaveSystem.SaveData(gamesPlayed, newTimePlayed, data.highScoreEasy, data.highScoreMedium, data.highScoreDifficult,
                        newMaxScore, data.highScoreMediumRight, data.highScoreDifficultRight,
                        data.highScoreEasyLeft, data.highScoreMediumLeft, data.highScoreDifficultLeft,
                        data.numberGames2, data.timePlayed2, data.highScoreEasy2, data.highScoreMedium2, data.highScoreDifficult2,
                        data.highScoreEasyRight2, data.highScoreMediumRight2, data.highScoreDifficultRight2,
                        data.highScoreEasyLeft2, data.highScoreMediumLeft2, data.highScoreDifficultLeft2);
                }
                if (LevelLoader.instance.difficulte == 2)
                {
                    int maxScore = data.highScoreMediumRight;
                    int newMaxScore = maxScore;
                    if (currentScore > maxScore)
                    {
                        newMaxScore = currentScore;
                    }
                    SaveSystem.SaveData(gamesPlayed, newTimePlayed, data.highScoreEasy, data.highScoreMedium, data.highScoreDifficult,
                        data.highScoreEasyRight, newMaxScore, data.highScoreDifficultRight,
                        data.highScoreEasyLeft, data.highScoreMediumLeft, data.highScoreDifficultLeft,
                        data.numberGames2, data.timePlayed2, data.highScoreEasy2, data.highScoreMedium2, data.highScoreDifficult2,
                        data.highScoreEasyRight2, data.highScoreMediumRight2, data.highScoreDifficultRight2,
                        data.highScoreEasyLeft2, data.highScoreMediumLeft2, data.highScoreDifficultLeft2);
                }
                if (LevelLoader.instance.difficulte == 3)
                {
                    int maxScore = data.highScoreDifficultRight;
                    int newMaxScore = maxScore;
                    if (currentScore > maxScore)
                    {
                        newMaxScore = currentScore;
                    }
                    SaveSystem.SaveData(gamesPlayed, newTimePlayed, data.highScoreEasy, data.highScoreMedium, data.highScoreDifficult,
                        data.highScoreEasyRight, data.highScoreMediumRight, newMaxScore,
                        data.highScoreEasyLeft, data.highScoreMediumLeft, data.highScoreDifficultLeft,
                        data.numberGames2, data.timePlayed2, data.highScoreEasy2, data.highScoreMedium2, data.highScoreDifficult2,
                        data.highScoreEasyRight2, data.highScoreMediumRight2, data.highScoreDifficultRight2,
                        data.highScoreEasyLeft2, data.highScoreMediumLeft2, data.highScoreDifficultLeft2);
                }
            }
            if (LevelLoader.instance.leftHand)
            {
                if (LevelLoader.instance.difficulte == 1)
                {
                    int maxScore = data.highScoreEasyLeft;
                    int newMaxScore = maxScore;
                    if (currentScore > maxScore)
                    {
                        newMaxScore = currentScore;
                    }
                    SaveSystem.SaveData(gamesPlayed, newTimePlayed, data.highScoreEasy, data.highScoreMedium, data.highScoreDifficult,
                        data.highScoreEasyRight, data.highScoreMediumRight, data.highScoreDifficultRight,
                        newMaxScore, data.highScoreMediumLeft, data.highScoreDifficultLeft,
                        data.numberGames2, data.timePlayed2, data.highScoreEasy2, data.highScoreMedium2, data.highScoreDifficult2,
                        data.highScoreEasyRight2, data.highScoreMediumRight2, data.highScoreDifficultRight2,
                        data.highScoreEasyLeft2, data.highScoreMediumLeft2, data.highScoreDifficultLeft2);
                }
                if (LevelLoader.instance.difficulte == 2)
                {
                    int maxScore = data.highScoreMediumLeft;
                    int newMaxScore = maxScore;
                    if (currentScore > maxScore)
                    {
                        newMaxScore = currentScore;
                    }
                    SaveSystem.SaveData(gamesPlayed, newTimePlayed, data.highScoreEasy, data.highScoreMedium, data.highScoreDifficult,
                        data.highScoreEasyRight, data.highScoreMediumRight, data.highScoreDifficultRight,
                        data.highScoreEasyLeft, newMaxScore, data.highScoreDifficultLeft,
                        data.numberGames2, data.timePlayed2, data.highScoreEasy2, data.highScoreMedium2, data.highScoreDifficult2,
                        data.highScoreEasyRight2, data.highScoreMediumRight2, data.highScoreDifficultRight2,
                        data.highScoreEasyLeft2, data.highScoreMediumLeft2, data.highScoreDifficultLeft2);
                }
                if (LevelLoader.instance.difficulte == 3)
                {
                    int maxScore = data.highScoreDifficultLeft;
                    int newMaxScore = maxScore;
                    if (currentScore > maxScore)
                    {
                        newMaxScore = currentScore;
                    }
                    SaveSystem.SaveData(gamesPlayed, newTimePlayed, data.highScoreEasy, data.highScoreMedium, data.highScoreDifficult,
                        data.highScoreEasyRight, data.highScoreMediumRight, data.highScoreDifficultRight,
                        data.highScoreEasyLeft, data.highScoreMediumLeft, newMaxScore,
                        data.numberGames2, data.timePlayed2, data.highScoreEasy2, data.highScoreMedium2, data.highScoreDifficult2,
                        data.highScoreEasyRight2, data.highScoreMediumRight2, data.highScoreDifficultRight2,
                        data.highScoreEasyLeft2, data.highScoreMediumLeft2, data.highScoreDifficultLeft2);
                }
            }
            if (!LevelLoader.instance.leftHand && !LevelLoader.instance.rightHand)
            {
                if (LevelLoader.instance.difficulte == 1)
                {
                    int maxScore = data.highScoreEasy;
                    int newMaxScore = maxScore;
                    if (currentScore > maxScore)
                    {
                        newMaxScore = currentScore;
                    }
                    SaveSystem.SaveData(gamesPlayed, newTimePlayed, newMaxScore, data.highScoreMedium, data.highScoreDifficult,
                        data.highScoreEasyRight, data.highScoreMediumRight, data.highScoreDifficultRight,
                        data.highScoreEasyLeft, data.highScoreMediumLeft, data.highScoreDifficultLeft,
                        data.numberGames2, data.timePlayed2, data.highScoreEasy2, data.highScoreMedium2, data.highScoreDifficult2,
                        data.highScoreEasyRight2, data.highScoreMediumRight2, data.highScoreDifficultRight2,
                        data.highScoreEasyLeft2, data.highScoreMediumLeft2, data.highScoreDifficultLeft2);
                }
                if (LevelLoader.instance.difficulte == 2)
                {
                    int maxScore = data.highScoreMedium;
                    int newMaxScore = maxScore;
                    if (currentScore > maxScore)
                    {
                        newMaxScore = currentScore;
                    }
                    SaveSystem.SaveData(gamesPlayed, newTimePlayed, data.highScoreEasy, newMaxScore, data.highScoreDifficult,
                        data.highScoreEasyRight, data.highScoreMediumRight, data.highScoreDifficultRight,
                        data.highScoreEasyLeft, data.highScoreMediumLeft, data.highScoreDifficultLeft,
                        data.numberGames2, data.timePlayed2, data.highScoreEasy2, data.highScoreMedium2, data.highScoreDifficult2,
                        data.highScoreEasyRight2, data.highScoreMediumRight2, data.highScoreDifficultRight2,
                        data.highScoreEasyLeft2, data.highScoreMediumLeft2, data.highScoreDifficultLeft2);
                }
                if (LevelLoader.instance.difficulte == 3)
                {
                    int maxScore = data.highScoreDifficult;
                    int newMaxScore = maxScore;
                    if (currentScore > maxScore)
                    {
                        newMaxScore = currentScore;
                    }
                    SaveSystem.SaveData(gamesPlayed, newTimePlayed, data.highScoreEasy, data.highScoreMedium, newMaxScore,
                        data.highScoreEasyRight, data.highScoreMediumRight, data.highScoreDifficultRight,
                        data.highScoreEasyLeft, data.highScoreMediumLeft, data.highScoreDifficultLeft,
                        data.numberGames2, data.timePlayed2, data.highScoreEasy2, data.highScoreMedium2, data.highScoreDifficult2,
                        data.highScoreEasyRight2, data.highScoreMediumRight2, data.highScoreDifficultRight2,
                        data.highScoreEasyLeft2, data.highScoreMediumLeft2, data.highScoreDifficultLeft2);
                }
            }
        }
        if (LevelLoader.instance.game2)
        {
            int gamesPlayed = data.numberGames2 + 1;
            int newTimePlayed = data.timePlayed2 + 3;
            if (LevelLoader.instance.rightHand)
            {
                if (LevelLoader.instance.difficulte == 1)
                {
                    int maxScore = data.highScoreEasyRight2;
                    int newMaxScore = maxScore;
                    if (currentScore > maxScore)
                    {
                        newMaxScore = currentScore;
                    }
                    SaveSystem.SaveData(data.numberGames, data.timePlayed, data.highScoreEasy, data.highScoreMedium, data.highScoreDifficult,
                        data.highScoreEasyRight, data.highScoreMediumRight, data.highScoreDifficultRight,
                        data.highScoreEasyLeft, data.highScoreMediumLeft, data.highScoreDifficultLeft,
                        gamesPlayed, newTimePlayed, data.highScoreEasy2, data.highScoreMedium2, data.highScoreDifficult2,
                        newMaxScore, data.highScoreMediumRight2, data.highScoreDifficultRight2,
                        data.highScoreEasyLeft2, data.highScoreMediumLeft2, data.highScoreDifficultLeft2);
                }
                if (LevelLoader.instance.difficulte == 2)
                {
                    int maxScore = data.highScoreMediumRight2;
                    int newMaxScore = maxScore;
                    if (currentScore > maxScore)
                    {
                        newMaxScore = currentScore;
                    }
                    SaveSystem.SaveData(data.numberGames, data.timePlayed, data.highScoreEasy, data.highScoreMedium, data.highScoreDifficult,
                        data.highScoreEasyRight, data.highScoreMediumRight, data.highScoreDifficultRight,
                        data.highScoreEasyLeft, data.highScoreMediumLeft, data.highScoreDifficultLeft,
                        gamesPlayed, newTimePlayed, data.highScoreEasy2, data.highScoreMedium2, data.highScoreDifficult2,
                        data.highScoreEasyRight2, newMaxScore, data.highScoreDifficultRight2,
                        data.highScoreEasyLeft2, data.highScoreMediumLeft2, data.highScoreDifficultLeft2);
                }
                if (LevelLoader.instance.difficulte == 3)
                {
                    int maxScore = data.highScoreDifficultRight2;
                    int newMaxScore = maxScore;
                    if (currentScore > maxScore)
                    {
                        newMaxScore = currentScore;
                    }
                    SaveSystem.SaveData(data.numberGames, data.timePlayed, data.highScoreEasy, data.highScoreMedium, data.highScoreDifficult,
                        data.highScoreEasyRight, data.highScoreMediumRight, data.highScoreDifficultRight,
                        data.highScoreEasyLeft, data.highScoreMediumLeft, data.highScoreDifficultLeft,
                        gamesPlayed, newTimePlayed, data.highScoreEasy2, data.highScoreMedium2, data.highScoreDifficult2,
                        data.highScoreEasyRight2, data.highScoreMediumRight2, newMaxScore,
                        data.highScoreEasyLeft2, data.highScoreMediumLeft2, data.highScoreDifficultLeft2);
                }
            }
            if (LevelLoader.instance.leftHand)
            {
                if (LevelLoader.instance.difficulte == 1)
                {
                    int maxScore = data.highScoreEasyLeft2;
                    int newMaxScore = maxScore;
                    if (currentScore > maxScore)
                    {
                        newMaxScore = currentScore;
                    }
                    SaveSystem.SaveData(data.numberGames, data.timePlayed, data.highScoreEasy, data.highScoreMedium, data.highScoreDifficult,
                        data.highScoreEasyRight, data.highScoreMediumRight, data.highScoreDifficultRight,
                        data.highScoreEasyLeft, data.highScoreMediumLeft, data.highScoreDifficultLeft,
                        gamesPlayed, newTimePlayed, data.highScoreEasy2, data.highScoreMedium2, data.highScoreDifficult2,
                        data.highScoreEasyRight2, data.highScoreMediumRight2, data.highScoreDifficultRight2,
                        newMaxScore, data.highScoreMediumLeft2, data.highScoreDifficultLeft2);
                }
                if (LevelLoader.instance.difficulte == 2)
                {
                    int maxScore = data.highScoreMediumLeft2;
                    int newMaxScore = maxScore;
                    if (currentScore > maxScore)
                    {
                        newMaxScore = currentScore;
                    }
                    SaveSystem.SaveData(data.numberGames, data.timePlayed, data.highScoreEasy, data.highScoreMedium, data.highScoreDifficult,
                        data.highScoreEasyRight, data.highScoreMediumRight, data.highScoreDifficultRight,
                        data.highScoreEasyLeft, data.highScoreMediumLeft, data.highScoreDifficultLeft,
                        gamesPlayed, newTimePlayed, data.highScoreEasy2, data.highScoreMedium2, data.highScoreDifficult2,
                        data.highScoreEasyRight2, data.highScoreMediumRight2, data.highScoreDifficultRight2,
                        data.highScoreEasyLeft2, newMaxScore, data.highScoreDifficultLeft2);
                }
                if (LevelLoader.instance.difficulte == 3)
                {
                    int maxScore = data.highScoreDifficultLeft2;
                    int newMaxScore = maxScore;
                    if (currentScore > maxScore)
                    {
                        newMaxScore = currentScore;
                    }
                    SaveSystem.SaveData(data.numberGames, data.timePlayed, data.highScoreEasy, data.highScoreMedium, data.highScoreDifficult,
                        data.highScoreEasyRight, data.highScoreMediumRight, data.highScoreDifficultRight,
                        data.highScoreEasyLeft, data.highScoreMediumLeft, data.highScoreDifficultLeft,
                        gamesPlayed, newTimePlayed, data.highScoreEasy2, data.highScoreMedium2, data.highScoreDifficult2,
                        data.highScoreEasyRight2, data.highScoreMediumRight2, data.highScoreDifficultRight2,
                        data.highScoreEasyLeft2, data.highScoreMediumLeft2, newMaxScore);
                }
            }
            if (!LevelLoader.instance.leftHand && !LevelLoader.instance.rightHand)
            {
                if (LevelLoader.instance.difficulte == 1)
                {
                    int maxScore = data.highScoreEasy2;
                    int newMaxScore = maxScore;
                    if (currentScore > maxScore)
                    {
                        newMaxScore = currentScore;
                    }
                    SaveSystem.SaveData(data.numberGames, data.timePlayed, data.highScoreEasy, data.highScoreMedium, data.highScoreDifficult,
                        data.highScoreEasyRight, data.highScoreMediumRight, data.highScoreDifficultRight,
                        data.highScoreEasyLeft, data.highScoreMediumLeft, data.highScoreDifficultLeft,
                        gamesPlayed, newTimePlayed, newMaxScore, data.highScoreMedium2, data.highScoreDifficult2,
                        data.highScoreEasyRight2, data.highScoreMediumRight2, data.highScoreDifficultRight2,
                        data.highScoreEasyLeft2, data.highScoreMediumLeft2, data.highScoreDifficultLeft2);
                }
                if (LevelLoader.instance.difficulte == 2)
                {
                    int maxScore = data.highScoreMedium2;
                    int newMaxScore = maxScore;
                    if (currentScore > maxScore)
                    {
                        newMaxScore = currentScore;
                    }
                    SaveSystem.SaveData(data.numberGames, data.timePlayed, data.highScoreEasy, data.highScoreMedium, data.highScoreDifficult,
                        data.highScoreEasyRight, data.highScoreMediumRight, data.highScoreDifficultRight,
                        data.highScoreEasyLeft, data.highScoreMediumLeft, data.highScoreDifficultLeft,
                        gamesPlayed, newTimePlayed, data.highScoreEasy2, newMaxScore, data.highScoreDifficult2,
                        data.highScoreEasyRight2, data.highScoreMediumRight2, data.highScoreDifficultRight2,
                        data.highScoreEasyLeft2, data.highScoreMediumLeft2, data.highScoreDifficultLeft2);
                }
                if (LevelLoader.instance.difficulte == 3)
                {
                    int maxScore = data.highScoreDifficult2;
                    int newMaxScore = maxScore;
                    if (currentScore > maxScore)
                    {
                        newMaxScore = currentScore;
                    }
                    SaveSystem.SaveData(data.numberGames, data.timePlayed, data.highScoreEasy, data.highScoreMedium, data.highScoreDifficult,
                        data.highScoreEasyRight, data.highScoreMediumRight, data.highScoreDifficultRight,
                        data.highScoreEasyLeft, data.highScoreMediumLeft, data.highScoreDifficultLeft,
                        gamesPlayed, newTimePlayed, data.highScoreEasy2, data.highScoreMedium2, newMaxScore,
                        data.highScoreEasyRight2, data.highScoreMediumRight2, data.highScoreDifficultRight2,
                        data.highScoreEasyLeft2, data.highScoreMediumLeft2, data.highScoreDifficultLeft2);
                }
            }
        }        
    }
}
