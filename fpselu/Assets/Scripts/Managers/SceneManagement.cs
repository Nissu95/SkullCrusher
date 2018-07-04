using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{

    public static SceneManagement singleton;


    [SerializeField]
    GameObject loadingBarCanvas;
    [SerializeField]
    Image loadingBar;

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
            MyLoadScenes(winScene, true);

        level++;
    }

    void MyLoadScenes(string scene, bool cursorVisible)
    {
        Cursor.visible = cursorVisible;
        if (cursorVisible)
            Cursor.lockState = CursorLockMode.None;
        else
            Cursor.lockState = CursorLockMode.Locked;

        StartCoroutine(LoadAsynchronously(scene));
    }

    IEnumerator LoadAsynchronously(string scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);

        loadingBarCanvas.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadingBar.rectTransform.localScale = new Vector3(progress / 1, 1, 1);
            Debug.Log(progress);

            yield return null;
        }

        if (operation.isDone)
            loadingBarCanvas.SetActive(false);
    }

}
