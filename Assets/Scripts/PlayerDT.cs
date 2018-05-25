using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDT : MonoBehaviour {

    [SerializeField] ElementData[] data;
    private int elementIndex = 0;

	void Start () {

	}

	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
            if (elementIndex < data.Length)
                elementIndex++;
            else
                elementIndex = 0;

        if (Input.GetKeyDown(KeyCode.Q))
            if (elementIndex > 0)
                elementIndex--;
            else
                elementIndex = data.Length;
	}

    public float GetDamage() {
        
        return data[elementIndex].damage;
    }

    public float GetDefense() {

        return data[elementIndex].defense;
    }

}
