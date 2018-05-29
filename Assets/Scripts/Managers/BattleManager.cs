using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    public static BattleManager singleton;

    void Awake() {
        if (singleton == null)
            singleton = this;
        else
            Debug.LogError("Battle Manager duplicado", gameObject);
    }
}
