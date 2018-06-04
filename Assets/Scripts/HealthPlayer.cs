using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthPlayer : MonoBehaviour {

    [SerializeField] float MaxHealth;
    [SerializeField] string gameOverScene;
    [SerializeField] Image healthBar;

    private float currentHealth;
    
	void Start () {
        currentHealth = MaxHealth;
	}

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
            Death();

        healthBar.transform.localScale = new Vector3(currentHealth / MaxHealth, 1, 1);
    }
    
    void Death()
    {
        SceneManager.LoadScene(gameOverScene);
    }
}
