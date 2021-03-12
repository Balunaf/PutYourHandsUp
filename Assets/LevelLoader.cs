using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMain;

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

    public void LoadLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}