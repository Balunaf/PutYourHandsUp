using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour
{
    [SerializeField] private Text score; //le texte pour afficher le score

    public int arret; //pour gérer le nombre de balles arrêtées
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //on affiche le score du joueur pour qu'il ait un suivi en jeu
    void Update()
    {
        score.text = "Nombre de balles arrêtées : " + arret.ToString();
    }
}
