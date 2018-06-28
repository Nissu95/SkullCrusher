using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float enemyMaxHealth;
    [SerializeField] AudioClip deathSound;
    [SerializeField] UnityEvent deathEvent;

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
        deathEvent.Invoke();

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
        //Destroy(gameObject);
        this.gameObject.SetActive(false);
    }

    public bool IsAlive()
    {
        return isAlive;
    }
}
