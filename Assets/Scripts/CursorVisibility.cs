using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorVisibility : MonoBehaviour {
    
    [SerializeField] bool visible;

	void Start ()
    {

        if (visible)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        
	}
}
