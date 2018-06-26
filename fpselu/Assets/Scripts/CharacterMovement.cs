using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    [SerializeField] private float gravity;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashCooldown;
    [SerializeField] private float runSpeed;
    [SerializeField] private float maxResistance;
    [SerializeField] private float fatigue;
    [SerializeField] private float recovery;

    private Vector3 velocity;
    private CharacterController cc;
    private Animator anim;
    private float horizontal;
    private float vertical;
    float speed;
    float timer;
    float resistance;

	void Start () {
        cc = GetComponentInChildren<CharacterController>();
        anim = GetComponent<Animator>();
        velocity = Vector3.zero;
        speed = moveSpeed;
        timer = dashCooldown;
        resistance = maxResistance;
	}
	
	void Update () {

        timer += Time.deltaTime;

        UIManager.singleton.imageDashCooldown(timer, dashCooldown);
        UIManager.singleton.imageResistanceBar(maxResistance, resistance);

        /*if (!cc.isGrounded)
            velocity.y -= gravity * Time.deltaTime;*/
        speed = moveSpeed;
        if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftShift) && timer >= dashCooldown && velocity != Vector3.zero)
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
            

        vertical = Input.GetAxis("Vertical") * speed;
        horizontal = Input.GetAxis("Horizontal") * speed;
        
        anim.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        anim.SetFloat("Vertical", Input.GetAxis("Vertical"));

        velocity.x = 0;
        velocity.z = 0;

        velocity.x += transform.forward.x * vertical;
        velocity.z += transform.forward.z * vertical;

        velocity.x += transform.right.x * horizontal;
        velocity.z += transform.right.z * horizontal;

        cc.Move(velocity * Time.deltaTime);
	}
}
