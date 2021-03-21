using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource sourceHitBall; //source audio pour la touche de balle

    [SerializeField] private AudioSource sourceSendBall; //source audio pour l'envoi de balle

    [SerializeField] private AudioClip hitBall; //sond pour la touche de balle

    [SerializeField] private AudioClip sendBall; //soon pour l'envoi de balle
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //fonction à appeler pour lire le son de touche de balle
    public void HitBall()
    {
        sourceHitBall.loop = false;
        sourceHitBall.PlayOneShot(hitBall);
    }

    //fonction à appeler pour lire le son d'envoi de balle
    public void SendBall()
    {
        sourceSendBall.loop = false;
        sourceSendBall.PlayOneShot(sendBall);
    }
}
