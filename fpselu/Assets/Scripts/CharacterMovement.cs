using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CharacterMovement : MonoBehaviour {

    [SerializeField] private float gravity;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashCooldown;
    [SerializeField] private float runSpeed;
    [SerializeField] private float maxResistance;
    [SerializeField] private float fatigue;
    [SerializeField] private float recovery;
    [SerializeField] private AudioClip[] footSteps;

    [SerializeField] LeftJoystick leftJoystick;
    [SerializeField] RightJoystick rightJoystick;

    public int rotationSpeed = 8; // rotation speed of the player character


    private Vector3 velocity;
    private CharacterController cc;
    private Animator anim;
    private AudioSource aS;
    private float horizontal;
    private float vertical;
    float speed;
    float timer;
    float resistance;

	void Start () {
        cc = GetComponentInChildren<CharacterController>();
        anim = GetComponent<Animator>();
        aS = GetComponent<AudioSource>();
        velocity = Vector3.zero;
        speed = moveSpeed;
        timer = dashCooldown;
        resistance = maxResistance;
	}
	
	void Update () {

        timer += Time.deltaTime;
        
        /*if (!cc.isGrounded)
            velocity.y -= gravity * Time.deltaTime;*/
        speed = moveSpeed;
        if (CrossPlatformInputManager.GetButtonDown("Dash") && timer >= dashCooldown && velocity != Vector3.zero)
        {
            speed = dashSpeed;
            timer = 0;
        }
        else if (Input.GetKey(KeyCode.LeftShift) && velocity != Vector3.zero && resistance > 0)
        {
            speed = runSpeed;
            resistance -= fatigue;
        }
        else if (resistance < maxResistance && !Input.GetKey(KeyCode.LeftShift))
            resistance += recovery;

        UIManager.singleton.imageDashCooldown(timer, dashCooldown);
        UIManager.singleton.imageResistanceBar(maxResistance, resistance);

#if UNITY_ANDROID

        Vector2 leftJoystickInput  = leftJoystick.GetInputDirection();

        float xMovementLeftJoystick = leftJoystickInput.x; // The horizontal movement from joystick 01
        float zMovementLeftJoystick = leftJoystickInput.y; // The vertical movement from joystick 01	

        horizontal = xMovementLeftJoystick * speed;
        vertical = zMovementLeftJoystick * speed;

#elif UNITY_STANDALONE_WIN

        vertical = Input.GetAxis("Vertical") * speed;
        horizontal = Input.GetAxis("Horizontal") * speed;

#endif

        anim.SetFloat("Horizontal", horizontal);
        anim.SetFloat("Vertical", vertical);

        velocity.x = 0;
        velocity.z = 0;

        velocity.x += transform.forward.x * vertical;
        velocity.z += transform.forward.z * vertical;

        velocity.x += transform.right.x * horizontal;
        velocity.z += transform.right.z * horizontal;

        cc.Move(velocity * Time.deltaTime);
	}

    private void FootStep()
    {
        aS.PlayOneShot(GetRandomClip());
    }

    private AudioClip GetRandomClip()
    {
        return footSteps[Random.Range(0, footSteps.Length - 1)];
    }
}
