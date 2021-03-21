using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public float x; //position de la balle en x

    public float y; //position de la balle en y

    public float z = 20; //position de la balle en z, par défaut à 20 quand on la lance

    private float yi; //position de la balle en y quand elle est lancée

    private float xf; //force de la balle en x quand elle repart

    private float yf; //force de la balle en y quand elle repart

    private float zf; //force de la balle en z quand elle repart

    private bool stopped = false; //booléen pour savoir si la balle a été arrêtée

    private bool behind = false; //booléen pour savoir si la balle a dépassé le joueur

    private float time = 0; //pour gérer le temps

    private float t = 0; //pour gérer le temps avec une 2e variable

    private Vector3 force; //pour gérer la force de la balle

    private float yn; //position de la balle en y quand elle arrive

    //Sound variables
    [SerializeField] private AudioSource sourcePassed;

    [SerializeField] private AudioClip passed;

    private bool played;

    // Start is called before the first frame update
    void Start()
    {
        played = false;
    }

    private void OnEnable() //on calcule une force random
    {
        zf = Random.Range(9f, 11f);
        yf = Random.Range(2f, 4f);
        xf = Random.Range(-1f, 1f);
        force = new Vector3(xf, yf, zf);
        yi = y;
        while (!isGoodForce(force)) //tant que la force random n'envoie pas la balle dans une zone accessible au joueur,
                                    //on en calcule une autre
        {
            zf = Random.Range(9f, 11f);
            yf = Random.Range(2f, 4f);
            xf = Random.Range(-1f, 1f);
            force = new Vector3(xf, yf, zf);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stopped) //si la balle est stoppée, elle repart dans l'autre sens
        {
            time += Time.deltaTime;
            t += Time.deltaTime;
            z += force.z * Time.deltaTime;
            y = yn -(3f * t * t) / 2 + force.y * t;
            x += force.x * Time.deltaTime;
            transform.position = new Vector3(x, y, z);
        }
        else
        {
            if (behind) //si la balle est derrière le joueur, on augmente time pour savoir quand la détruire
            {
                time += Time.deltaTime;
            }
            else
            {
                if (z > -2) //tant que la balle est devant le joueur, elle avance selon sa force
                {
                    t += Time.deltaTime;
                    z -= force.z * Time.deltaTime;
                    y = -(3f * t * t)/2 + force.y * t + yi;
                    x += force.x * Time.deltaTime;
                    transform.position = new Vector3(x, y, z);
                }
                else //si la balle passe derrière le joueur
                {
                    behind = true;
                }
            }
            if (z < 1.4 && !played) //on lance le son quand la balle est suffisament proche du joueur
            {
                PassedBall();
            }
        }
        //temps avant la destuction de la balle différent selon les deux jeux
        if (time > 1 && LevelLoader.instance.game1)
        {
            time = 0;
            Destroy(gameObject);
        }
        if (time > 2 && LevelLoader.instance.game2)
        {
            time = 0;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //detection de collision différente selon les deux jeux
        //pour chacune, on calcule une force de retour et on dit que la balle a été arrêtée
        if (other.CompareTag("Hand") && LevelLoader.instance.game1)
        {
            stopped = true;
            yn = transform.position.y;
            zf = Random.Range(2f, 3f);
            yf = Random.Range(1f, 2f);
            xf = Random.Range(-1f, 1f);
            force = new Vector3(xf, yf, zf);
            t = 0;
        }
        if (other.CompareTag("Racket") && LevelLoader.instance.game2)
        {
            stopped = true;
            yn = transform.position.y;
            zf = Random.Range(9f, 11f);
            yf = Random.Range(2f, 4f);
            xf = Random.Range(-1f, 1f);
            force = new Vector3(xf, yf, zf);
            t = 0;
        }
    }

    //fonction pour savoir si la force enverra la balle dans un endroit accessible au joueur
    bool isGoodForce(Vector3 f)
    {
        float tf = 19.3f / f.z; //temps que mettra la balle pour arriver juste devant le joueur
        float xfinal = x + f.x * tf; //x de la balle quand elle arrivera juste devant le joueur
        float yfinal = y - (3 * tf * tf) / 2 + f.y * tf; //y de la balle quand elle arrivera juste devant le joueur
        bool right = LevelLoader.instance.rightHand;
        bool left = LevelLoader.instance.leftHand;
        //on calcule si le x et le y sont bons selon la difficulté et les mains choisies
        if (LevelLoader.instance.difficulte == 1 && yfinal > -0.3f && yfinal < 0.4f)
        {
            if (right && xfinal > 0 && xfinal < 0.4f)
            {
                return true;
            }
            if (left && xfinal > -0.4f && xfinal < 0)
            {
                return true;
            }
            if ((!right) && (!left) && xfinal > -0.4f && xfinal < 0.4f)
            {
                return true;
            }
        }
        if (LevelLoader.instance.difficulte == 2 && yfinal > 0 && yfinal < 0.5f)
        {
            if (right && xfinal > 0.1f && xfinal < 0.5f)
            {
                return true;
            }
            if (left && xfinal > -0.5f && xfinal < -0.1f)
            {
                return true;
            }
            if ((!right) && (!left) && ((xfinal > -0.5f && xfinal < -0.1f) || (xfinal > 0.1f && xfinal < 0.5f)))
            {
                return true;
            }
        }
        if (LevelLoader.instance.difficulte == 3 && yfinal > 0.3f && yfinal < 0.6f)
        {
            if (right && xfinal > 0.2f && xfinal < 0.6f)
            {
                return true;
            }
            if (left && xfinal > -0.6f && xfinal < -0.2f)
            {
                return true;
            }
            if ((!right) && (!left) && ((xfinal > -0.6f && xfinal < -0.2f) || (xfinal > 0.2f && xfinal < 0.6f)))
            {
                return true;
            }
        }
        return false;
    }

    //fonction pour lire le son de la balle quand elle passe à côté du joueur
    private void PassedBall()
    {
        sourcePassed.loop = false;
        sourcePassed.PlayOneShot(passed);
        played = true;
    }
}