using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    [SerializeField] string enemyTag;
    [SerializeField] float swordDamage;
    [SerializeField] float attackCooldown;

    float timer;

    void Start()
    {
        timer = attackCooldown;
    }

    void Update()
    {
        timer += Time.deltaTime;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(enemyTag) && Input.GetMouseButtonDown(0) && timer >= attackCooldown)
        {
            string enemyName = other.GetComponent<EnemyDT>().data.name;
            string playerElementName = PlayerManager.singleton.GetName();
            other.GetComponent<EnemyHealth>().TakeDamage(PlayerManager.singleton.GetDamage() * BattleManager.singleton.ElementMultiplier(playerElementName, enemyName));
            timer = 0;
            Debug.Log("asdas");
        }
    }

}
