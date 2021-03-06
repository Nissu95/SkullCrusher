using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] string playerTag;
    [SerializeField] float enemyDamage;
    [SerializeField] float timeCollider;
    [SerializeField] BoxCollider swordCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            swordCollider.enabled = false;
            var myName = GetComponent<EnemyDT>().data.name;
            var playerElementName = PlayerManager.singleton.GetName();
            other.GetComponent<HealthPlayer>().TakeDamage(enemyDamage * BattleManager.singleton.ElementMultiplier(myName, playerElementName));
        }
    }
}
