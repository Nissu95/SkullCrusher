using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager singleton;
    
    [SerializeField]  Image dashCooldown;

    void Awake()
    {
        DontDestroyOnLoad(this);
        if (singleton != null)
        {
            Debug.LogError("UI Manager duplicado", gameObject);
            Destroy(this);
        }
        else
            singleton = this;
    }

    public void imageDashCooldown(float timer, float cooldown){
        dashCooldown.fillAmount = timer / cooldown;
    }

}
