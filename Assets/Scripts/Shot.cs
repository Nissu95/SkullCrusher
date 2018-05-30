using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

    private Pool pool;

    void Start() {
    }

	void Update () {
        
        if (Input.GetMouseButtonDown(0))
        {
            pool = PoolManager.GetInstance().GetPool(PlayerManager.singleton.GetName() + "ProyectilePool");

            PoolObject po = pool.GetPooledObject();
            po.gameObject.transform.position = transform.position;
            po.gameObject.transform.rotation= Camera.main.transform.rotation;

            po.gameObject.tag = PlayerManager.singleton.GetName();

            /*GameObject proyectile = PlayerManager.singleton.GetBulletPrefab();
            proyectile.transform.position = transform.position;
            proyectile.transform.rotation = Camera.main.transform.rotation;
            Instantiate(proyectile);*/
        }
        
    }
}
