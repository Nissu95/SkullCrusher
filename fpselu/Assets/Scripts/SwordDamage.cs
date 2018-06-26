using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    [SerializeField] string enemyTag;
    [SerializeField] float swordDamage;
    [SerializeField] float attackCooldown;
    [SerializeField] string[] attackParameters;

    private Animator anim;
    BoxCollider swordCollider;
    float timer;

    void Start()
    {
        swordCollider = GetComponent<BoxCollider>();
        swordCollider.enabled = false;
        timer = attackCooldown;
        anim = GetComponentInParent<Animator>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && timer >= attackCooldown)
        {
            swordCollider.enabled = true;
            anim.SetTrigger(attackParameters[Random.Range(0,attackParameters.Length-1)]);
            timer = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(enemyTag))
        {
            swordCollider.enabled = false;
            string enemyName = other.GetComponent<EnemyDT>().data.name;
            string playerElementName = PlayerManager.singleton.GetName();
            other.GetComponent<EnemyHealth>().TakeDamage(PlayerManager.singleton.GetDamage() * BattleManager.singleton.ElementMultiplier(playerElementName, enemyName));
        }
    }

}
