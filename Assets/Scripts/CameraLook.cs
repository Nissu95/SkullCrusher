using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour {
    [SerializeField]
    float sensitivity;
    [SerializeField]
    Transform cameraTrans;

	void Update () {
        cameraTrans.Rotate(-Input.GetAxis("Mouse Y") * sensitivity, 0 , 0);
        transform.Rotate(0 , Input.GetAxis("Mouse X") * sensitivity, 0);
    }
}
