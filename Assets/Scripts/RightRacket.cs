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

    [SerializeField] private Text goodBall;

    [SerializeField] private RightHandManager rightHand;

    private float time;

    public bool rtouch = false;

    private float x;

    private float y;

    private float z;

    private float rotx;

    private float roty;

    private float rotz;

    private float rotw;
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
        if (time > 1)
        {
            rtouch = false;
            rightHand.rtouch = false;
        }
        x = rightHand.transform.position.x;
        y = rightHand.transform.position.y;
        z = rightHand.transform.position.z;
        transform.position = new Vector3(x, y, z);
        rotx = rightHand.transform.rotation.x;
        roty = rightHand.transform.rotation.y;
        rotz = rightHand.transform.rotation.z;
        rotw = rightHand.transform.rotation.w;
        transform.rotation = new Quaternion(rotx, roty, rotz, rotw);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") && time > 1 && !leftRacket.ltouch && LevelLoader.instance.game2)
        {
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
            rightHand.Vibration();
        }
    }
}
