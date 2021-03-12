using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource sourceClickButton;

    [SerializeField] private AudioClip clickButton;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ClickButton()
    {
        sourceClickButton.loop = false;
        sourceClickButton.PlayOneShot(clickButton);
    }
}
