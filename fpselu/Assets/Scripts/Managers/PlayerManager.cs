using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager singleton;

    private GameObject m_Player;

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

        UIManager.singleton.SwitchMaterial();
    }

	void Update () {
        if (InputManager.singleton.GetButtonDown("Next Element"))
        {
            if (elementIndex < data.Length - 1)
                elementIndex++;
            else
                elementIndex = 0;

            UIManager.singleton.SwitchMaterial();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (elementIndex > 0)
                elementIndex--;
            else
                elementIndex = data.Length - 1;

            UIManager.singleton.SwitchMaterial();
        }
    }

    public float GetDamage() {
        
        return data[elementIndex].damage;
    }

    public string GetName() {
        return data[elementIndex].name;
    }

    public void SetPlayerInstance(GameObject player)
    {
        m_Player = player;
    }

    public GameObject GetPlayerInstance()
    {
        return m_Player;
    }
}
