using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	enum EnemyType {Fire,Water,Plant};

	[SerializeField] EnemyType type;

	private Pool pool;

	void Start () 
	{
		switch (type) 
		{
		case EnemyType.Fire:
			pool = PoolManager.GetInstance ().GetPool ("FireEnemiesPool");
			break;
		case EnemyType.Plant:
			pool = PoolManager.GetInstance ().GetPool ("PlantEnemiesPool");
			break;
		case EnemyType.Water:
			pool = PoolManager.GetInstance ().GetPool ("WaterEnemiesPool");
			break;
		}

		PoolObject po = pool.GetPooledObject();
		po.gameObject.transform.position = transform.position;
	}
}

