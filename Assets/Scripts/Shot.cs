using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

    [SerializeField] GameObject m_Camera;
    [SerializeField] string enemyTag;

    PlayerDT pl;

    void Start() {

        pl = GetComponent<PlayerDT>();

    }

	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if(Physics.Raycast(m_Camera.transform.position, m_Camera.transform.forward, out hit))
                if (hit.collider.CompareTag(enemyTag))
                 hit.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(pl.GetDamage());
        }
        
    }
}
