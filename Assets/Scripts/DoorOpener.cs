using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOpener : MonoBehaviour {
    [SerializeField] string NextLevel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<KeyScript>().HasKey())
                SceneManager.LoadScene(NextLevel);

        }
    }
}
