using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

    public static SceneManagement singleton;

    [SerializeField]
    string menuScene;
    [SerializeField]
    string gameOverScene;
    [SerializeField]
    string winScene;
    [SerializeField]
    string[] levels;

    uint level;

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

    public void LoadMenu()
    {
        MyLoadScenes(menuScene, true);
    }

    public void LoadGameOver()
    {
        MyLoadScenes(gameOverScene, true);
    }

    public void LoadWin()
    {
        MyLoadScenes(winScene, true);
    }

    public void LoadLevel()
    {
        Debug.Log("Cargando nivel");

        if (level < levels.Length)
            MyLoadScenes(levels[level], false);
        else
            MyLoadScenes(menuScene, true);

        level++;
    }

    void MyLoadScenes(string scene, bool cursorVisible)
    {
        Cursor.visible = cursorVisible;
        if (cursorVisible)
            Cursor.lockState = CursorLockMode.None;
        else
            Cursor.lockState = CursorLockMode.Locked;

        SceneManager.LoadScene(scene);
    }

}
