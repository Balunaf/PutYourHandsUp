using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightRacket : MonoBehaviour
{
    [SerializeField] private ScoreManager score; //le score

    [SerializeField] private AudioManager audioManager; //l'audio

    [SerializeField] private ScoreUpdate scoreUpdate; //le score en jeu

    [SerializeField] private Text goodBall; //le texte pour savoir si on a renvoyé la balle assez fort

    [SerializeField] private RightHandManager rightHand; //la main gauche

    private float time; //pour gérer le temps

    public bool rtouch = false; //pour savoir si la raquette à touché quelque chose

    private float x; //la position de la raquette en x

    private float y; //la position de la raquette en y

    private float z; //la position de la raquette en z

    private float rotx; //la rotation de la raquette en x

    private float roty; //la rotation de la raquette en y

    private float rotz; //la rotation de la raquette en z

    private float rotxi; //la rotation initiale de la main en x

    private float rotyi; //la rotation initiale de la main en y

    private float rotzi; //la rotation initiale de la main en z
    // Start is called before the first frame update
    void Start()
    {
        if (LevelLoader.instance.leftHand) //on n'active pas la raquette droite si le jouer a choisi main gauche
        {
            gameObject.SetActive(false);
        }
        //on récupère la rotation initiale de la main
        rotxi = rightHand.transform.rotation.x;
        rotyi = rightHand.transform.rotation.y;
        rotzi = rightHand.transform.rotation.z;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 1) //on permet au joueur de retoucher une balle
        {
            rtouch = false;
            rightHand.rtouch = false;
        }
        //on lie la position de la raquette à celle de la main
        x = rightHand.transform.position.x;
        y = rightHand.transform.position.y;
        z = rightHand.transform.position.z;
        transform.position = new Vector3(x, y, z);
        //on lie la rotation de la raquette à celle de la main
        rotx = rotxi - rightHand.transform.rotation.x;
        roty = rotyi - rightHand.transform.rotation.y;
        rotz = rotzi - rightHand.transform.rotation.z;
        transform.eulerAngles = new Vector3((360*rotx / Mathf.PI)%360, (360*roty / Mathf.PI)%360, (360*rotz / Mathf.PI)%360);
    }
    private void OnTriggerEnter(Collider other)
    {
        //collision avec la balle que dans le jeu 2
        if (other.CompareTag("Ball") && time > 1 && LevelLoader.instance.game2)
        {
            //on vérifie que la vitesse de la raquette est suffisante
            if ((GetComponent<Rigidbody>().velocity.magnitude > 50 && LevelLoader.instance.difficulte == 1) ||
                (GetComponent<Rigidbody>().velocity.magnitude > 60 && LevelLoader.instance.difficulte == 2) ||
                (GetComponent<Rigidbody>().velocity.magnitude > 70 && LevelLoader.instance.difficulte == 3))
            {
                scoreUpdate.arret += 1;
                score.arret += 1;
                goodBall.text = "Bon renvoi !";
            }
            else
            {
                goodBall.text = "Un peu plus fort la prochaine fois.";
            }
            audioManager.HitBall();
            time = 0;
            rtouch = true;
            rightHand.rtouch = true;
            rightHand.Vibration(); //on active la vibration de la manette
        }
    }
}
