using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public bool leftHand;

    public bool rightHand;

    [SerializeField] Button mainBoutton;

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
    private void Start()
    {
        mainBoutton.onClick.AddListener(() => ChangeHands());
        leftHand = false;
        rightHand = false;
    }
    public void LoadLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ChangeHands()
    {
        if (!leftHand & !rightHand)
        {
            leftHand = false;
            rightHand = true;
        }
        else if (!leftHand & rightHand)
        {
            leftHand = true;
            rightHand = false;
        }
        else
        {
            leftHand = false;
            rightHand = false;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}