using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyScript : MonoBehaviour {

    [SerializeField] string nextLevel;

    bool hasKey = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            hasKey = true;
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Door") && hasKey)
            LoadLevel();
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
