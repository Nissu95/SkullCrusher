using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float enemyMaxHealth;

    private EnemyIA EIA;
    private Animator anim;
    private float currentHealth;
    private bool isAlive = true;

    void Start()
    {
        anim = GetComponent<Animator>();
        EIA = GetComponent<EnemyIA>();
        currentHealth = enemyMaxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            isAlive = false;
            Death();
        }
        else
        {
            anim.SetTrigger("Hit");
            EIA.Stunn();
        }
            
    }

    void Death()
    {
        anim.SetTrigger("Fall");
        Invoke("Destruction", 5);
    }

    void Destruction()
    {
        Destroy(gameObject);
    }

    public bool IsAlive()
    {
        return isAlive;
    }
}
