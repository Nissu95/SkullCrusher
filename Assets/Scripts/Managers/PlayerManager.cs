using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager singleton;

    [SerializeField] ElementData[] data;
    private int elementIndex = 0;

    void Awake()
    {
        DontDestroyOnLoad(this);
        if (singleton != null)
        {
            Debug.LogError("Player Manager duplicado", gameObject);
            Destroy(gameObject);
        }
        else
            singleton = this;
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
    }

    public float GetDamage() {
        
        return data[elementIndex].damage;
    }

    public string GetName() {
        return data[elementIndex].name;
    }

    public Color GetColorParticles()
    {
        switch (data[elementIndex].name)
        {
            case "Fire":
                return Color.red;
            case "Water":
                return Color.blue;
            case "Plant":
                return Color.green;
            default:
                return Color.white;
        }
    }
}
