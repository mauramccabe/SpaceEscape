using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=h2d9Wc3Hhi0

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed;
    public float jumpForce;
    public CharacterController controller;
    public float gravityScale;
    public Vector3 moveDirection;

    public GameObject spring;

    private float lastGrounded = 0;

    private bool springJump;

    public delegate void JumpHandler();
    public static event JumpHandler onJump;
    public static event JumpHandler onLand;


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // probably need to change this to fixed update but will need some debugging so im not doing it rn
    void Update()
    {
        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        
        //normalize movedirection so you dont get double speed when moving diagonally.
        moveDirection = Vector3.ClampMagnitude(moveDirection,1) * moveSpeed;
        moveDirection.y = yStore;



        if (controller.isGrounded) {
            if ((lastGrounded != 0.2f) && (onLand != null))
                onLand();
            moveDirection.y = 0f;
            lastGrounded = 0.2f;

        } else if (lastGrounded > 0) {
            lastGrounded = lastGrounded - Time.deltaTime;
        }

        if (lastGrounded > 0) {
            if (Input.GetButtonDown("Jump")) {
                moveDirection.y = jumpForce;
                lastGrounded = 0f;

                if(onJump != null)
                    onJump();
            }
        }


        if (springJump) {
            moveDirection.y = jumpForce * 2;
            springJump = false;
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y  * gravityScale *Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.tag == "Spring") {
            springJump = true;    
        }
    }
}
