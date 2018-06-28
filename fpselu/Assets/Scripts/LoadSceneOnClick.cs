using UnityEngine;
using UnityEngine.UI;

public class LoadSceneOnClick : MonoBehaviour
{
    public void LoadLevelOne()
    {
        SceneManagement.singleton.LoadLevelOne();
    }

    public void LoadMenu()
    {
        SceneManagement.singleton.LoadMenu();
    }
}
