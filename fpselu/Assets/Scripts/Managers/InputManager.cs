using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class InputManager : MonoBehaviour {


    public static InputManager singleton;

    void Awake()
    {
        DontDestroyOnLoad(this);
        if (singleton != null)
        {
            Debug.LogError("Input Manager duplicado", gameObject);
            Destroy(gameObject);
        }
        else
            singleton = this;
    }

    public float GetAxis(string axis)
    {
#if UNITY_ANDROID
        return CrossPlatformInputManager.GetAxis(axis);
#elif UNITY_STANDALONE_WIN
        return Input.GetAxis(axis);
# endif
    }

    public bool GetButtonDown(string button)
    {
#if UNITY_ANDROID
        return CrossPlatformInputManager.GetButtonDown(button);
#elif UNITY_STANDALONE_WIN
        return Input.GetButtonDown(button);
# endif
    }

}
