using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    float currentHealth;
    EnemyDT enemyType;

    void Start()
    {
        enemyType = GetComponent<EnemyDT>();
        currentHealth = enemyType.GetMaxHealth();
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
