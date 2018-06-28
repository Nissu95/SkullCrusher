using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour {

    [SerializeField] float maxHealth;

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
        SceneManagement.singleton.LoadDeath();
    }
}
