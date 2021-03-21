using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMain; //l'affichage des mains sélectionnées

    [SerializeField] private TextMeshProUGUI textDifficulte; //l'affichage de la difficulté sélectionnée

    [SerializeField] private Canvas option; //le menu d'option pour les statistiques

    public bool game1; //pour savoir si on est dans le jeu 1

    public bool game2; //pour savoir si on est dans le jeu 2

    public bool leftHand; //pour savoir si on a que la main gauche

    public bool rightHand; //pour savoir si on a que la main droite

    public int difficulte; //pour savoir quelle est la difficulté choisie

    public static LevelLoader instance; //pour créer une instance
    //on crée une instance pour pouvoir accéder à tous les attrbuts public n'importe où dans le jeu
    private void Awake()
    {
        if (instance)
        {
            Debug.LogError("Il y a déjà une instance de GameManager" + name);
            Destroy(this);
        }
        else instance = this;
    }

    void Start()
    {
        difficulte = 1;
        textDifficulte.text = "FACILE (22 BALLES)";
        leftHand = false;
        rightHand = false;
        game1 = false;
        game2 = false;
        textMain.text = "DEUX MAINS";
    }

    public void ChangeHands()
    {
        if (!leftHand & !rightHand)
        {
            leftHand = false;
            rightHand = true;
            textMain.text = "MAIN DROITE";
        }
        else
        {
            if (!leftHand & rightHand)
            {
                leftHand = true;
                rightHand = false;
                textMain.text = "MAIN GAUCHE";
            }
            else
            {
                leftHand = false;
                rightHand = false;
                textMain.text = "DEUX MAINS";
            }
        }
    }
    public void ChangeDifficulty()
    {
        if (difficulte == 1)
        {
            difficulte = 2;
            textDifficulte.text = "MOYEN (29 BALLES)";
        }
        else
        {
            if (difficulte == 2)
            {
                difficulte = 3;
                textDifficulte.text = "DIFFICILE (35 BALLES)";
            }
            else
            {
                difficulte = 1;
                textDifficulte.text = "FACILE (22 BALLES)";
            }
        }
    }

    public void LoadLevel(int sceneIndex)
    {
        if (sceneIndex == 1)
        {
            game1 = true;
            SceneManager.LoadScene(sceneIndex);
        }
        if (sceneIndex == 2 && !(!rightHand && !leftHand))
        {
            game2 = true;
            SceneManager.LoadScene(sceneIndex);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Option()
    {
        option.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}