using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileScript : MonoBehaviour {

    [SerializeField] float proyectileSpeed;
    [SerializeField] float maxTime;
    [SerializeField] string enemyTag;
    [SerializeField] string stageTag;

    float timer;

    private void OnEnable()
    {
        RestartTimer();
    }

    void Update () {
        transform.Translate(0, 0, proyectileSpeed * Time.deltaTime);

        if (timer > 0)
            timer -= Time.deltaTime;

        if (timer <= 0)
            GetComponent<PoolObject>().Recycle();
    }

    void OnTriggerEnter(Collider other) {

        if (other.CompareTag(enemyTag)) {
            GetComponent<PoolObject>().Recycle();
            var enemy = other.GetComponent<EnemyHealth>();
            var enemyName = other.GetComponent<EnemyDT>().data.name;
            var playerElementName = PlayerManager.singleton.GetName();
            enemy.TakeDamage(PlayerManager.singleton.GetDamage() * BattleManager.singleton.ElementMultiplier(playerElementName, enemyName));
        }

        if (other.CompareTag(stageTag))
            GetComponent<PoolObject>().Recycle();
    }

    public void RestartTimer()
    {
        timer = maxTime;
    }
}
