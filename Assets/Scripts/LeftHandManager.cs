using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandManager : MonoBehaviour
{
    [SerializeField] private ScoreManager score; //le score

    [SerializeField] private RightHandManager rightHand; //la main droite

    [SerializeField] private AudioManager audioManager; //l'audio

    [SerializeField] private ScoreUpdate scoreUpdate; //le score en jeu

    private float time; //pour gérer le temps

    public bool ltouch = false; //pour savoir si la balle a touché quelque chose
    // Start is called before the first frame update
    void Start()
    {
        if (LevelLoader.instance.rightHand) //on active pas la main gauche si le joueur a choisi main droite
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 0.05) //on stoppe la vibration
        {
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
        }
        if (time > 1) //on permet au joueur de retoucher une balle
        {
            ltouch = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //collision avec la main que dans le jeu 1
        if (other.CompareTag("Ball") && time > 1 && !rightHand.rtouch && LevelLoader.instance.game1)
        {
            audioManager.HitBall();
            scoreUpdate.arret += 1;
            score.arret += 1;
            time = 0;
            ltouch = true;
            Vibration();
        }
    }
    //fonction à appeler pour lancer la vibration de la manette
    public void Vibration()
    {
        OVRInput.SetControllerVibration(0.5f, 1, OVRInput.Controller.LTouch);
        time = 0;
    }
}
