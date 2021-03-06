using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{

    public static SceneManagement singleton;


    [SerializeField] GameObject loadingBarCanvas;
    [SerializeField] Image loadingBar;
    [SerializeField] string menuScene;
    [SerializeField] string gameOverScene;
    [SerializeField] string winScene;
    [SerializeField] string[] levels;

    uint level = 0;

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
        level = 0;
        MyLoadScenes(menuScene, true);
    }

    public void LoadGameOver()
    {
        UIManager.singleton.gameObject.SetActive(false);
        MyLoadScenes(gameOverScene, true);
        level = 0;
    }

    public void LoadWin()
    {
        MyLoadScenes(winScene, true);
    }

    public void LoadLevel()
    {
        Debug.Log("Cargando nivel: " + level);

        if (level < levels.Length)
        {
            UIManager.singleton.gameObject.SetActive(true);
            MyLoadScenes(levels[level], false);
        }
        else
        {
            UIManager.singleton.gameObject.SetActive(false);
            LoadWin();
        }

        level++;
    }

    void MyLoadScenes(string scene, bool cursorVisible)
    {
#if UNITY_STANDALONE_WIN
        Cursor.visible = cursorVisible;
        if (cursorVisible)
            Cursor.lockState = CursorLockMode.None;
        else
            Cursor.lockState = CursorLockMode.Locked;
#endif


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

            yield return null;
        }

        if (operation.isDone)
            loadingBarCanvas.SetActive(false);
    }

}
