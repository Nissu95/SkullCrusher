using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Pool pool;

	// Use this for initialization
	void Start () {
        pool = PoolManager.GetInstance().GetPool("PoolDeCubos");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PoolObject po = pool.GetPooledObject();
            po.gameObject.transform.position = Random.insideUnitSphere * 10.0f;
        }	
	}
}
