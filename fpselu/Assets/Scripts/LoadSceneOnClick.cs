using UnityEngine;
using UnityEngine.UI;

public class LoadSceneOnClick : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManagement.singleton.LoadLevel();
    }

    public void LoadMenu()
    {
        SceneManagement.singleton.LoadMenu();
    }
}
