using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour {

    private float currentHealth;

    const float MaxHealth=100f;

	// Use this for initialization
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

    }
}
