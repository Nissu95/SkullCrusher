using UnityEngine;

public class KeyScript : MonoBehaviour {

    [SerializeField] AudioClip keySound;

    AudioSource aS;
    bool hasKey = false;

    void Start()
    {
        aS = GetComponent<AudioSource>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            aS.PlayOneShot(keySound);
            hasKey = true;
            other.gameObject.SetActive(false);
        }
    }

    public bool HasKey()
    {
        return hasKey;
    }
}
