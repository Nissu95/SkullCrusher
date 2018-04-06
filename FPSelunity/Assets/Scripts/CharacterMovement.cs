using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    [SerializeField] private float gravity;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;

    private Vector3 velocity;
    private CharacterController cc;
    private float horizontal;
    private float vertical;

	void Start () {
        cc = GetComponent<CharacterController>();
        velocity = Vector3.zero;
	}
	
	void Update () {

        if (!cc.isGrounded)
        {
            velocity.y -= gravity * Time.deltaTime;
        }
        else
        {
            if (cc.isGrounded && Input.GetKeyDown(KeyCode.Space))
                velocity.y = jumpSpeed;
            else
                velocity.y = 0;
        }

        vertical = Input.GetAxis("Vertical") * moveSpeed;
        horizontal = Input.GetAxis("Horizontal") * moveSpeed;
        velocity.x = 0;
        velocity.z = 0;

        velocity.x += transform.forward.x * vertical;
        velocity.z += transform.forward.z * vertical;

        velocity.x += transform.right.x * horizontal;
        velocity.z += transform.right.z * horizontal;

        cc.Move(velocity * Time.deltaTime);
	}
}
