using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftRacket : MonoBehaviour
{
    [SerializeField] private ScoreManager score;

    [SerializeField] private RightRacket rightRacket;

    [SerializeField] private AudioManager audioManager;

    [SerializeField] private ScoreUpdate scoreUpdate;

    [SerializeField] private Text goodBall;

    [SerializeField] private LeftHandManager leftHand;

    private float time;

    public bool ltouch = false;

    private float x;

    private float y;

    private float z;

    private float rotx;

    private float roty;

    private float rotz;

    private float rotw;

    private float rotxi;

    private float rotyi;

    private float rotzi;

    private float rotwi;
    // Start is called before the first frame update
    void Start()
    {
        if (LevelLoader.instance.rightHand)
        {
            gameObject.SetActive(false);
        }
        rotxi = leftHand.transform.rotation.x;
        rotyi = leftHand.transform.rotation.y;
        rotzi = leftHand.transform.rotation.z;
        rotwi = leftHand.transform.rotation.w;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 1)
        {
            ltouch = false;
            leftHand.ltouch = false;
        }
        x = leftHand.transform.position.x;
        y = leftHand.transform.position.y;
        z = leftHand.transform.position.z;
        transform.position = new Vector3(x, y, z);
        rotx = leftHand.transform.rotation.x - rotxi;
        roty = leftHand.transform.rotation.y - rotyi;
        rotz = leftHand.transform.rotation.z - rotzi;
        rotw = leftHand.transform.rotation.w - rotwi;
        transform.eulerAngles = new Vector3(rotx, roty, rotz);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") && time > 1 && !rightRacket.rtouch && LevelLoader.instance.game2)
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
            ltouch = true;
            leftHand.ltouch = true;
            leftHand.Vibration();
        }
    }
}
