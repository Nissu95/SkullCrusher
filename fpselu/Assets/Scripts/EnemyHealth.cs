using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float enemyMaxHealth;
    [SerializeField] GameObject[] particles;
    [SerializeField] AudioClip deathSound;

    private EnemyIA EIA;
    
    private Animator anim;
    private float currentHealth;
    private bool isAlive = true;
    private AudioSource aS;

    void Start()
    {
        anim = GetComponent<Animator>();
        EIA = GetComponent<EnemyIA>();
        aS = GetComponent<AudioSource>();
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
        for (int i = 0; i < particles.Length; i++)
            particles[i].SetActive(false);

        if (deathSound)
            aS.PlayOneShot(deathSound);
        else
            Debug.Log("No hay sonido de muerte");

        if (!anim.GetBool("IsDead"))
            anim.SetBool("IsDead", true);
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
