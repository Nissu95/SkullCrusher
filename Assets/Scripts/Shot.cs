using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

    PlayerDT pl;

    void Start() {

        pl = GetComponent<PlayerDT>();

    }

	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            GameObject go = pl.GetBulletPrefab();
            Instantiate(go);
        }
        
    }
}
