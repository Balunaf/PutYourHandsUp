using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource sourceHitBall;

    [SerializeField] private AudioSource sourceSendBall;

    [SerializeField] private AudioClip hitBall;

    [SerializeField] private AudioClip sendBall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HitBall()
    {
        sourceHitBall.loop = false;
        sourceHitBall.PlayOneShot(hitBall);
    }
    public void SendBall()
    {
        sourceSendBall.loop = false;
        sourceSendBall.PlayOneShot(sendBall);
    }
}
