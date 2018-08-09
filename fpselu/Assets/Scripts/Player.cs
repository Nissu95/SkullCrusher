using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private static Player instance;

	public static Player GetInstance()
	{
		if (!instance)
			instance = new Player ();
		else
			Destroy (instance);

		return instance;
	}

}
