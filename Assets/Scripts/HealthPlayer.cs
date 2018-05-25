using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour {

    private float currentHealth;

    [SerializeField] float MaxHealth;
    
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
        Debug.Log("Game Over PT");
    }
}
