using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour {

    [SerializeField] float maxHealth;
    [SerializeField] string gameOverScene;
    [SerializeField] AudioClip[] playerGrunts;

    int lastGrunt = 0;

    private AudioSource aS;
    private float currentHealth;
    
	void Start () {
        aS = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        UIManager.singleton.resetHealthBar();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
            Death();
        else
            Grunt();

        UIManager.singleton.imageHealthBar(currentHealth, maxHealth);
    }
    
    void Death()
    {
        SceneManagement.singleton.LoadDeath();
    }

    void Grunt()
    {
        aS.PlayOneShot(GetRandomClip());
    }

    AudioClip GetRandomClip()
    {
        int aux = 0; 
        do
        {
            aux = Random.Range(0, playerGrunts.Length);
        } while (aux == lastGrunt);

        lastGrunt = aux;

        return playerGrunts[aux];
    }
}
