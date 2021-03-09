using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public bool left;

    public bool right;

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
    public void LoadLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}