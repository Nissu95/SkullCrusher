using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthPlayer : MonoBehaviour {

    [SerializeField] float maxHealth;
    [SerializeField] string gameOverScene;

    private float currentHealth;
    
	void Start () {
        currentHealth = maxHealth;
        UIManager.singleton.resetHealthBar();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
            Death();

        UIManager.singleton.imageHealthBar(currentHealth, maxHealth);
    }
    
    void Death()
    {
        SceneManager.LoadScene(gameOverScene);
    }
}
