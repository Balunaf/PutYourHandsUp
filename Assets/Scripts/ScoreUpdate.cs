using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour
{
    [SerializeField] private Text score;

    public int arret;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Nombre de balles arrêtées : " + arret.ToString();
    }
}
