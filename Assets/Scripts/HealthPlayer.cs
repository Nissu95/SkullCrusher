using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthPlayer : MonoBehaviour {

    [SerializeField] float MaxHealth;
    [SerializeField] string gameOverScene;

    private float currentHealth;
    
	void Start () {
        currentHealth = MaxHealth;
	}

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
            Death();
    }
    
    void Death()
    {
        SceneManager.LoadScene(gameOverScene);
    }
}
