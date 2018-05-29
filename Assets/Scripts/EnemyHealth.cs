using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
     [SerializeField] float enemyMaxHealth;

    float currentHealth;

    void Start()
    {
        currentHealth = enemyMaxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
            Death();
    }

    void Death()
    {
        Destroy(this.gameObject);
    }
}
