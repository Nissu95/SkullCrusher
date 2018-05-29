using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    [SerializeField] EnemyDT enemyType;

    public static BattleManager singleton;

    void Awake() {
        if (singleton == null)
            singleton = this;
        else
            Debug.LogError("Battle Manager duplicado", gameObject);
    }

    public float ElementMultiplier(string attackerName, string reciberName) {

        if (attackerName == reciberName)
            return 1;
        if (attackerName == "Fire" && reciberName == "Plant")
            return 2;
        if (attackerName == "Fire" && reciberName == "Water")
            return 0.5f;
        if (attackerName == "Water" && reciberName == "Fire")
            return 2;
        if (attackerName == "Water" && reciberName == "Plant")
            return 0.5f;
        if (attackerName == "Plant" && reciberName == "Water")
            return 2;
        if (attackerName == "Plant" && reciberName == "Fire")
            return 0.5f;
        
        return 0;
    }

}
