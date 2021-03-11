using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Slider sliderMain;

    [SerializeField] private Text textMain;

    [SerializeField] private Slider sliderDifficulte;

    [SerializeField] private Text textDifficulte;

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
    }

    void Update()
    {
        float main = sliderMain.value;
        if(main == 1f)
        {
            textMain.text = "Deux mains";
            rightHand = false;
            leftHand = false;
        }
        if(main == 2f)
        {
            textMain.text = "Main droite";
            rightHand = true;
            leftHand = false;
        }
        if(main == 3f)
        {
            textMain.text = "Main gauche";
            rightHand = false;
            leftHand = true;
        }
        float dif = sliderDifficulte.value;
        if(dif == 1f)
        {
            textDifficulte.text = "Difficulté facile";
            difficulte = 1;
        }
        if(dif == 2f)
        {
            textDifficulte.text = "Difficulté moyenne";
            difficulte = 2;
        }
        if(dif == 3f)
        {
            textDifficulte.text = "Difficulté difficile";
            difficulte = 3;
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