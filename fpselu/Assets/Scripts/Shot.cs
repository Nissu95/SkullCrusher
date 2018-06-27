using UnityEngine;

public class Shot : MonoBehaviour {

    [SerializeField] float attackCooldown;

    private Pool pool;
    float timer;

    void Start() {
        timer = attackCooldown;
    }

	void Update () {

        timer += Time.deltaTime;

        UIManager.singleton.imageShotCooldown(timer, attackCooldown);

        if (InputManager.singleton.GetButtonDown("Fire2") && timer >= attackCooldown)
        {
            pool = PoolManager.GetInstance().GetPool(PlayerManager.singleton.GetName() + "ProyectilePool");

            PoolObject po = pool.GetPooledObject();
            po.gameObject.transform.position = transform.position;
            po.gameObject.transform.rotation= Camera.main.transform.rotation;

            po.gameObject.tag = PlayerManager.singleton.GetName();
            timer = 0;
        }
        
    }
}
