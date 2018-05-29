using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

    void Start() {
    }

	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            GameObject proyectile = PlayerManager.singleton.GetBulletPrefab();
            proyectile.transform.position = transform.position;
            proyectile.transform.rotation = Camera.main.transform.rotation;
            Instantiate(proyectile);
        }
        
    }
}
