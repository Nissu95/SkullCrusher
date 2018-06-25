using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float enemyMaxHealth;

    Animator anim;
    float currentHealth;

    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = enemyMaxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        anim.SetTrigger("Hit");
        if (currentHealth <= 0)
            Death();
    }

    void Death()
    {
        Destroy(this.gameObject);
    }
}
