using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDT : MonoBehaviour
{
    public EnemyData data;

    public float GetMaxHealth()
    {
        return data.maxHealth;
    }

    public float GetDamage() {
        return data.damage;
    }

}
