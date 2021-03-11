using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandManager : MonoBehaviour
{
    [SerializeField] private ScoreManager score;

    [SerializeField] private LeftHandManager leftHand;

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
        if (time > 1)
        {
            rtouch = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") && time > 1 && !leftHand.ltouch)
        {
            score.arret += 1;
            time = 0;
            rtouch = true;
        }
    }
}
