using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandManager : MonoBehaviour
{
    [SerializeField] private ScoreManager score; //le score

    [SerializeField] private LeftHandManager leftHand; //la main gauche

    [SerializeField] private AudioManager audioManager; //l'audio

    [SerializeField] private ScoreUpdate scoreUpdate; //le score en jeu

    private float time; //pour gérer le temps

    public bool rtouch = false; //pour savoir si la main a touché quelque chose
    // Start is called before the first frame update
    void Start()
    {
        if (LevelLoader.instance.leftHand) //on n'active pas la main droite si le joueur a choisi main gauche
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
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        }
        if (time > 1) //on permet au joueur de retoucher une balle
        {
            rtouch = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //collision avec la balle que dans le jeu 1
        if (other.CompareTag("Ball") && time > 1 && !leftHand.ltouch && LevelLoader.instance.game1)
        {
            score.arret += 1;
            audioManager.HitBall();
            scoreUpdate.arret += 1;
            time = 0;
            rtouch = true;
            Vibration();
        }
    }
    //fonction à appeler pour lancer la vibration de la manette
    public void Vibration()
    {
        OVRInput.SetControllerVibration(0.5f, 1, OVRInput.Controller.RTouch);
        time = 0;
    }
}
