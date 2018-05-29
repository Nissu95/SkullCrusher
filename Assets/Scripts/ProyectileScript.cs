﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileScript : MonoBehaviour {

    [SerializeField] float proyectileSpeed;
    [SerializeField] string enemyTag;
    [SerializeField] string stageTag;

    void Start() {
    }

	void Update () {
        transform.Translate(0, 0, proyectileSpeed * Time.deltaTime);
	}

    void OnTriggerEnter(Collider other) {

        if (other.CompareTag(enemyTag)) {
            var enemy = other.GetComponent<EnemyHealth>();
            var enemyName = other.GetComponent<EnemyDT>().data.name;
            var playerElementName = PlayerManager.singleton.GetName();
            enemy.TakeDamage(PlayerManager.singleton.GetDamage() * BattleManager.singleton.ElementMultiplier(playerElementName, enemyName));
        }

        if (other.CompareTag(stageTag))     //fijarse porque no funciona
            Destroy(this.gameObject);
    }

}
