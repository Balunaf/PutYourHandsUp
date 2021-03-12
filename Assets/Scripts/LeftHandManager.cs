using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandManager : MonoBehaviour
{
    [SerializeField] private ScoreManager score;

    [SerializeField] private RightHandManager rightHand;

    [SerializeField] private AudioManager audioManager;

    private float time;

    public bool ltouch = false;
    // Start is called before the first frame update
    void Start()
    {
        if (LevelLoader.instance.rightHand)
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
            ltouch = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") && time > 1 && !rightHand.rtouch)
        {
            audioManager.HitBall();
            score.arret += 1;
            time = 0;
            ltouch = true;
            OVRInput.SetControllerVibration(0.5f, 1, OVRInput.Controller.LTouch);
        }
    }
}
