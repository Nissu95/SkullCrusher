using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileScript : MonoBehaviour {

    [SerializeField] float proyectileSpeed;

    void Start() {
    }

	void Update () {
        transform.Translate(0, 0, proyectileSpeed * Time.deltaTime);
	}

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Enemy")) {
            var enemy = other.GetComponent<EnemyHealth>();
            enemy.TakeDamage(PlayerManager.singleton.GetDamage());
        }
    }

}
