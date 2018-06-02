using UnityEngine;

public class KeyScript : MonoBehaviour {
    
    bool hasKey = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            hasKey = true;
            other.gameObject.SetActive(false);
        }
    }

    public bool HasKey()
    {
        return hasKey;
    }
}
