using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

    [SerializeField] GameObject m_Camera;
    [SerializeField] float damage;

	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Physics.Raycast(m_Camera.transform.position, m_Camera.transform.forward, out hit);

            if (hit.collider.CompareTag("Enemy"))
                hit.collider.gameObject.GetComponent<HealthEnemy>().TakeDamage(damage);
        }
        
    }
}
