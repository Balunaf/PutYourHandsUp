using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuLoader : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    [SerializeField] ScoreManager score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    private void OnEnable()
    {
        canvas.gameObject.SetActive(false);
    }

    public void SaveData()
    {
        int currentScore = score.arret;
        GameData data = SaveSystem.LoadData();
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
                SaveSystem.SaveData(gamesPlayed, newTimePlayed, data.highScoreEasy, data.highScoreMedium, data.highScoreDifficult, newMaxScore, data.highScoreMediumRight, data.highScoreDifficultRight, data.highScoreEasyLeft, data.highScoreMediumLeft, data.highScoreDifficultLeft);
            }
            if (LevelLoader.instance.difficulte == 2)
            {
                int maxScore = data.highScoreMediumRight;
                int newMaxScore = maxScore;
                if (currentScore > maxScore)
                {
                    newMaxScore = currentScore;
                }
                SaveSystem.SaveData(gamesPlayed, newTimePlayed, data.highScoreEasy, data.highScoreMedium, data.highScoreDifficult, data.highScoreEasyRight, newMaxScore, data.highScoreDifficultRight, data.highScoreEasyLeft, data.highScoreMediumLeft, data.highScoreDifficultLeft);
            }
            if (LevelLoader.instance.difficulte == 3)
            {
                int maxScore = data.highScoreDifficultRight;
                int newMaxScore = maxScore;
                if (currentScore > maxScore)
                {
                    newMaxScore = currentScore;
                }
                SaveSystem.SaveData(gamesPlayed, newTimePlayed, data.highScoreEasy, data.highScoreMedium, data.highScoreDifficult, data.highScoreEasyRight, data.highScoreMediumRight, newMaxScore, data.highScoreEasyLeft, data.highScoreMediumLeft, data.highScoreDifficultLeft);
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
                SaveSystem.SaveData(gamesPlayed, newTimePlayed, data.highScoreEasy, data.highScoreMedium, data.highScoreDifficult, data.highScoreEasyRight, data.highScoreMediumRight, data.highScoreDifficultRight, newMaxScore, data.highScoreMediumLeft, data.highScoreDifficultLeft);
            }
            if (LevelLoader.instance.difficulte == 2)
            {
                int maxScore = data.highScoreMediumLeft;
                int newMaxScore = maxScore;
                if (currentScore > maxScore)
                {
                    newMaxScore = currentScore;
                }
                SaveSystem.SaveData(gamesPlayed, newTimePlayed, data.highScoreEasy, data.highScoreMedium, data.highScoreDifficult, data.highScoreEasyRight, data.highScoreMediumRight, data.highScoreDifficultRight, data.highScoreEasyLeft, newMaxScore, data.highScoreDifficultLeft);
            }
            if (LevelLoader.instance.difficulte == 3)
            {
                int maxScore = data.highScoreDifficultLeft;
                int newMaxScore = maxScore;
                if (currentScore > maxScore)
                {
                    newMaxScore = currentScore;
                }
                SaveSystem.SaveData(gamesPlayed, newTimePlayed, data.highScoreEasy, data.highScoreMedium, data.highScoreDifficult, data.highScoreEasyRight, data.highScoreMediumRight, data.highScoreDifficultRight, data.highScoreEasyLeft, data.highScoreMediumLeft, newMaxScore);
            }
        }
        if(!LevelLoader.instance.leftHand && !LevelLoader.instance.rightHand)
        {
            if (LevelLoader.instance.difficulte == 1)
            {
                int maxScore = data.highScoreEasy;
                int newMaxScore = maxScore;
                if (currentScore > maxScore)
                {
                    newMaxScore = currentScore;
                }
                SaveSystem.SaveData(gamesPlayed, newTimePlayed, newMaxScore, data.highScoreMedium, data.highScoreDifficult, data.highScoreEasyRight, data.highScoreMediumRight, data.highScoreDifficultRight, data.highScoreEasyLeft, data.highScoreMediumLeft, data.highScoreDifficultLeft);
            }
            if (LevelLoader.instance.difficulte == 2)
            {
                int maxScore = data.highScoreMedium;
                int newMaxScore = maxScore;
                if (currentScore > maxScore)
                {
                    newMaxScore = currentScore;
                }
                SaveSystem.SaveData(gamesPlayed, newTimePlayed, data.highScoreEasy, newMaxScore, data.highScoreDifficult, data.highScoreEasyRight, data.highScoreMediumRight, data.highScoreDifficultRight, data.highScoreEasyLeft, data.highScoreMediumLeft, data.highScoreDifficultLeft);
            }
            if (LevelLoader.instance.difficulte == 3)
            {
                int maxScore = data.highScoreDifficult;
                int newMaxScore = maxScore;
                if (currentScore > maxScore)
                {
                    newMaxScore = currentScore;
                }
                SaveSystem.SaveData(gamesPlayed, newTimePlayed, data.highScoreEasy, data.highScoreMedium, newMaxScore, data.highScoreEasyRight, data.highScoreMediumRight, data.highScoreDifficultRight, data.highScoreEasyLeft, data.highScoreMediumLeft, data.highScoreDifficultLeft);
            }
        }
    }
}
