using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileCanvas : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
#if !UNITY_ANDROID
        gameObject.SetActive(false);
#endif
    }
}
