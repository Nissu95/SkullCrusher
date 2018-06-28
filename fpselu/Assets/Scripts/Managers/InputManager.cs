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

#if UNITY_ANDROID

    public float GetAxis(string axis)
    {
        return CrossPlatformInputManager.GetAxis(axis);
    }

    public bool GetButtonDown(string button)
    {
         return CrossPlatformInputManager.GetButtonDown(button);
    }

#elif UNITY_STANDALONE_WIN

    public float GetAxis(string axis)
    {
        return Input.GetAxis(axis);
    }

    public bool GetButtonDown(string button)
    {
        return Input.GetButtonDown(button);
    }

#endif

}
