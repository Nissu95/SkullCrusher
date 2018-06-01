using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    public static BattleManager singleton;

    void Awake() {

        DontDestroyOnLoad(this);
        if (singleton != null)
        {
            Debug.LogError("Battle Manager duplicado", gameObject);
            Destroy(this);
        }
        else
            singleton = this;
    }

    public float ElementMultiplier(string attackerName, string receiverName) {

        if (attackerName == receiverName)
            return 1;
        if (attackerName == "Fire" && receiverName == "Plant")
            return 2;
        if (attackerName == "Fire" && receiverName == "Water")
            return 0.5f;
        if (attackerName == "Water" && receiverName == "Fire")
            return 2;
        if (attackerName == "Water" && receiverName == "Plant")
            return 0.5f;
        if (attackerName == "Plant" && receiverName == "Water")
            return 2;
        if (attackerName == "Plant" && receiverName == "Fire")
            return 0.5f;
        
        return 0;
    }

}
