using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager singleton;

    [SerializeField] Image[] images;

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

    public void imageDashCooldown(float timer, float cooldown) {
        images[3].fillAmount = timer / cooldown;
    }

    public void imageHealthBar(float currentHealth, float maxHealth) {
        images[2].transform.localScale = new Vector3 (currentHealth / maxHealth, 1, 1);
    }

    public void imageShotCooldown(float timer, float cooldown) {
        images[1].fillAmount = timer / cooldown;
    }

}
