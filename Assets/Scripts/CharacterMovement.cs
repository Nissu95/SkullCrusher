using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    [SerializeField] private float gravity;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashCooldown;
    [SerializeField] private float runSpeed;

    private Vector3 velocity;
    private CharacterController cc;
    private float horizontal;
    private float vertical;
    float speed;
    float timer;

	void Start () {
        cc = GetComponent<CharacterController>();
        velocity = Vector3.zero;
        speed = moveSpeed;
        timer = dashCooldown;
	}
	
	void Update () {

        timer += Time.deltaTime;

        UIManager.singleton.imageDashCooldown(timer, dashCooldown);

        /*if (!cc.isGrounded)
            velocity.y -= gravity * Time.deltaTime;*/

        if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftShift) && timer >= dashCooldown && velocity != Vector3.zero)
        {
            speed = dashSpeed;
            timer = 0;
        }
        else if (Input.GetKey(KeyCode.LeftShift) && velocity != Vector3.zero)
            speed = runSpeed;
        else
            speed = moveSpeed;       

        vertical = Input.GetAxis("Vertical") * speed;
        horizontal = Input.GetAxis("Horizontal") * speed;
        velocity.x = 0;
        velocity.z = 0;

        velocity.x += transform.forward.x * vertical;
        velocity.z += transform.forward.z * vertical;

        velocity.x += transform.right.x * horizontal;
        velocity.z += transform.right.z * horizontal;

        cc.Move(velocity * Time.deltaTime);
	}
}
