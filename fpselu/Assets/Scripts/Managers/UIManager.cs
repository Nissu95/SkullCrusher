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
            Destroy(gameObject);
        }
        else
            singleton = this;
    }

    public void imageDashCooldown(float timer, float cooldown) {
        images[3].fillAmount = timer / cooldown;
    }

    public void imageHealthBar(float currentHealth, float maxHealth) {
        images[2].rectTransform.localScale = new Vector3 (currentHealth / maxHealth, 1, 1);
    }

    public void resetHealthBar() {
        images[2].rectTransform.localScale = new Vector3(1, 1, 1);
    }

    public void imageShotCooldown(float timer, float cooldown) {
        images[1].fillAmount = timer / cooldown;
    }

    public void imageResistanceBar(float maxResistance, float resistance) {
        images[4].rectTransform.localScale = new Vector3(resistance / maxResistance, 1, 1);
    }

}
