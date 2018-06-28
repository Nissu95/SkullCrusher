using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

    public static SceneManagement singleton;

    [SerializeField]
    string[] scenes;

    int i = 0;

    void Awake()
    {
        DontDestroyOnLoad(this);
        if (singleton != null)
        {
            Debug.LogError("Scene Manager duplicado", gameObject);
            Destroy(gameObject);
        }
        else
            singleton = this;
    }

    public void LoadDeath()
    {
        SceneManager.LoadScene(scenes[3]);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene(scenes[1]);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void LoadScenes()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == scenes[1])
        {
            SceneManager.LoadScene(scenes[2]);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (sceneName == scenes[2])
        {
            SceneManager.LoadScene(scenes[0]);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(scenes[0]);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

}
