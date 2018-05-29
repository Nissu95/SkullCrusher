using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDT : MonoBehaviour {

    [SerializeField] ElementData[] data;
    [SerializeField] ParticleSystem pS;
    private int elementIndex = 0;

	void Start () {

	}

	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
            if (elementIndex < data.Length - 1)
                elementIndex++;
            else
                elementIndex = 0;

        if (Input.GetKeyDown(KeyCode.Q))
            if (elementIndex > 0)
                elementIndex--;
            else
                elementIndex = data.Length - 1;

        ChangeMaterial();
    }

    public float GetDamage() {
        
        return data[elementIndex].damage;
    }

    public GameObject GetBulletPrefab()
    {
        return data[elementIndex].bulletPref;
    }

    void ChangeMaterial()
    {
        switch (data[elementIndex].name)
        {
            case "Fire":
                pS.startColor = Color.red;
                break;
            case "Water":
                pS.startColor = Color.blue;
                break;
            case "Plant":
                pS.startColor = Color.green;
                break;
        }
    }
}
