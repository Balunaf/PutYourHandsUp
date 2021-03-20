using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionSelection : MonoBehaviour
{
    [SerializeField] private Canvas menu;

    [SerializeField] private Canvas jeu1;

    [SerializeField] private Canvas jeu2;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectGame1()
    {
        jeu1.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void SelectGame2()
    {
        jeu2.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void BackToMenu()
    {
        menu.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
