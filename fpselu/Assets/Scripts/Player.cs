using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
	void Start ()
    {
        PlayerManager.singleton.SetPlayerInstance(this.gameObject);
	}
	
}
