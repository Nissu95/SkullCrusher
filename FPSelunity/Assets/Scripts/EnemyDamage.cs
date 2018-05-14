using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] string playerTag;
    EnemyDT enemyType;

    void Start() {
        enemyType = GetComponent<EnemyDT>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            other.GetComponent<HealthPlayer>().TakeDamage(enemyType.GetDamage());
        }
    }
}
