using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionSelection : MonoBehaviour
{
    [SerializeField] private Canvas menu; //le menu principal

    [SerializeField] private Canvas jeu1; //le menu des statistiques du jeu 1

    [SerializeField] private Canvas jeu2; //le menu des statistiques du jeu 2
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //fonction à appeler pour charger le menu des statistiques du jeu 1
    public void SelectGame1()
    {
        jeu1.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    //fonction à appeler pour charger le menu des statistiques du jeu 2
    public void SelectGame2()
    {
        jeu2.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    //fonction à appeler pour charger le menu principal
    public void BackToMenu()
    {
        menu.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
