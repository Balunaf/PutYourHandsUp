using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightRacket : MonoBehaviour
{
    [SerializeField] private ScoreManager score;

    [SerializeField] private LeftRacket leftRacket;

    [SerializeField] private AudioManager audioManager;

    [SerializeField] private ScoreUpdate scoreUpdate;

    [SerializeField] private Rigidbody hand;

    [SerializeField] private Text goodBall;

    private float time;

    public bool rtouch = false;
    // Start is called before the first frame update
    void Start()
    {
        if (LevelLoader.instance.leftHand)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 0.05)
        {
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
        }
        if (time > 1)
        {
            rtouch = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") && time > 1 && !leftRacket.ltouch && LevelLoader.instance.game2)
        {
            if (hand.velocity.z > 1)
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
            OVRInput.SetControllerVibration(0.5f, 1, OVRInput.Controller.LTouch);
        }
    }
}
