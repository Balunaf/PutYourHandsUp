using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text score_text;

    public int score;

    public int total;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score_text.text = score.ToString() + " / " + total.ToString();
    }

    public void AddScore(int value)
    {
        score += 1;
    }
}
