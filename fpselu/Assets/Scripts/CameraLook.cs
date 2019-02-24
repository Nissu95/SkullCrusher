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

    [SerializeField] RightJoystick rightJoystick;

    float angle = 0.0f;
    Quaternion originalRotation;

    Vector3 rightJoystickInput; // hold the input of the Right Joystick

    void Update () {
        
        float yMovement = 0;
        float xMovement = 0;

#if UNITY_ANDROID
        rightJoystickInput = rightJoystick.GetInputDirection(); // The vertical movement from right joystick

        yMovement = rightJoystickInput.y;
        xMovement = rightJoystickInput.x;
#elif UNITY_STANDALONE_WIN
        yMovement = Input.GetAxis("Mouse Y");
        xMovement = Input.GetAxis("Mouse X");
#endif

        angle -= yMovement * sensitivity;

        if (angle > maxAngle)
            angle = maxAngle;
        else if (angle < minAngle)
            angle = minAngle;

        originalRotation = cameraTrans.localRotation;
        Vector3 euler = originalRotation.eulerAngles;
        euler.x = 0.0f;
        originalRotation.eulerAngles = euler;
        cameraTrans.localRotation = originalRotation * Quaternion.AngleAxis(angle, Vector3.right);


        transform.Rotate(0 , xMovement * sensitivity, 0);

    }
}
