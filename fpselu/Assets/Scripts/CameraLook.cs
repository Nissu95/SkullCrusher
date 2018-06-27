using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour {
    [SerializeField]
    float sensitivity;
    [SerializeField]
    Transform cameraTrans;
    [SerializeField]
    float maxAngle;
    [SerializeField]
    float minAngle;

    float angle = 0.0f;
    Quaternion originalRotation;

	void Update () {
        angle -= Input.GetAxis("Mouse Y") * sensitivity;

        if (angle > maxAngle)
        {
            angle = maxAngle;
        }
        else if (angle < minAngle)
        {
            angle = minAngle;
        }

        originalRotation = cameraTrans.localRotation;
        Vector3 euler = originalRotation.eulerAngles;
        euler.x = 0.0f;
        originalRotation.eulerAngles = euler;
        cameraTrans.localRotation = originalRotation * Quaternion.AngleAxis(angle, Vector3.right);

        transform.Rotate(0 , Input.GetAxis("Mouse X") * sensitivity, 0);
    }
}
