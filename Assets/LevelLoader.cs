using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Text textMain;

    public bool leftHand;

    public bool rightHand;

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
        textMain.text = "Deux Mains";
    }

    public void ChangeHands()
    {
        if (!leftHand & !rightHand)
        {
            leftHand = false;
            rightHand = true;
            textMain.text = "Main droite";
        }
        else if (!leftHand & rightHand)
        {
            leftHand = true;
            rightHand = false;
            textMain.text = "Main Gauche";
        }
        else
        {
            leftHand = false;
            rightHand = false;
            textMain.text = "Deux Mains";
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