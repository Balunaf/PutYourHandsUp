using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMain;

    [SerializeField] private TextMeshProUGUI textDifficulte;

    public bool leftHand;

    public bool rightHand;

    public int difficulte;

    public static LevelLoader instance;
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
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}