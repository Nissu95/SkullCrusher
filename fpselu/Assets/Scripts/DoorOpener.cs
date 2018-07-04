using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOpener : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<KeyScript>().HasKey())
                SceneManagement.singleton.LoadLevel();
        }
    }
}
