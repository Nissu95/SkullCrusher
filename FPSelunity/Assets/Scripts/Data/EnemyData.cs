using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Game/Data/Enemy"))]
public class EnemyData : ScriptableObject {

    public new string name;
    public string descriptopn;
    public float damage;
    public float defense;
    public float maxHealth;
}
