using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    [SerializeField] private BallManager originalBall = null; //pour connaître la balle à instancier

    [SerializeField] private ScoreManager score; //pour gérer le score

    [SerializeField] private AudioManager audioManager; //pour gérer le son

    public LineRenderer lineRenderer; //pour gérer le pop-up de fin

    public Canvas canvas; //pour gérer le pop-up de fin

    private float time = 0; //pour gérer le temps

    private float totalTime = 0; //pour gérer le temps passé en jeu

    private float x; //pour gérer la position en x du lanceur

    private float y; //pour gérer la position en x du lanceur

    private float z = 21; //pour gérer la position en x du lanceur

    // Start is called before the first frame update
    //on positionne le lanceur à une position aléatoire
    void Start()
    {
        x = Random.Range(-1f, 1f);
        y = Random.Range(-0.5f, 0.5f);
        transform.position = new Vector3(x, y, z);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        totalTime += Time.deltaTime;
        if (totalTime > 20) //la partie est finie, on affiche le pop-up de fin
        {
            canvas.gameObject.SetActive(true);
            lineRenderer.gameObject.SetActive(true);
        }
        if (totalTime < 18) //la partie n'est pas encore finie, on tire une balle, l'intervalle de tire dépend de la difficulté
        {
            if (time > 8 && LevelLoader.instance.difficulte == 1)
            {
                NewBall();
                time = 0;
            }
            if (time > 6 && LevelLoader.instance.difficulte == 2)
            {
                NewBall();
                time = 0;
            }
            if (time > 5 && LevelLoader.instance.difficulte == 3)
            {
                NewBall();
                time = 0;
            }
        } 
    }
    //fonction à appeler pour instancier une balle
    private void NewBall()
    {
        audioManager.SendBall();
        x = Random.Range(-0.5f, 0.5f); //on setup le x du lanceur
        y = Random.Range(0f, 1f); //on setup le y du lanceur
        transform.position = new Vector3(x, y, z);
        var newBall = Instantiate(originalBall, transform.position, transform.rotation); //on instancie la balle
        newBall.x = x; //on setup le x de départ de la balle avec celui du lanceur
        newBall.y = y; //on setup le y de départ de la balle avec celui du lanceur
        newBall.z = z - 1; //on setup le z de départ de la balle avec celui du lanceur, en étant un peu devant le lanceur
        newBall.gameObject.SetActive(true); //on active la balle
    }
}
