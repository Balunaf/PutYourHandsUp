using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource sourceClickButton; //la source pour le son quand on clique sur un bouton

    [SerializeField] private AudioClip clickButton; //le sond pour quand on clique sur un bouton
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //la fonction à appeler pour quand on clique sur un bouton
    public void ClickButton()
    {
        sourceClickButton.loop = false;
        sourceClickButton.PlayOneShot(clickButton);
    }
}
