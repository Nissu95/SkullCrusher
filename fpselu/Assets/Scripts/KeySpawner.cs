using UnityEngine;

public class KeySpawner : MonoBehaviour {

    [SerializeField] Transform keyTransform;
    [SerializeField] Transform[] spawnPoints;

    void Start()
    {
        SpawnKey();
    }

    void SpawnKey()
    {
        Vector3 aux = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
        keyTransform.position = new Vector3(aux.x, keyTransform.position.y, aux.z);
    }
}
