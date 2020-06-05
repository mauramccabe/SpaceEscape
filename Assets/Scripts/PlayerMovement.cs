using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//https://www.youtube.com/watch?v=h2d9Wc3Hhi0

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed;
    public float jumpForce;
    public CharacterController controller;
    public float gravityScale;
    public Vector3 moveDirection;


    Animator am;

    public float lastGrounded = 0;

    public bool springJump;

    public bool inAir = false;
    private bool canDash = true;
    public bool jumpflag = false;
    private float dashTime = 0;
    public float dashSpeed;

    public delegate void JumpHandler();
    public static event JumpHandler onJump;
    public static event JumpHandler onLand;
    public static event JumpHandler onLeaveGround;

    private int dashType;

    public bool tryJump = false;
    private bool tryDash = false;

    int sc;
    bool changeScene = false;


    public float springCD = 0;

    public float yStore;
    void Start() {
        controller = GetComponent<CharacterController>();
        am = gameObject.GetComponent<Animator>();
    }

    void OnAnimatorMove() {
    }


    void Update() {

        if (Input.GetKey(KeyCode.Alpha1)) {
            changeScene = true;
            sc = 0;
        }
        if (Input.GetKey(KeyCode.Alpha2)) {
            sc = 1;
            changeScene = true;
        }
        if (Input.GetKey(KeyCode.Alpha3)) {
            sc = 2;
            changeScene = true;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)
                                       || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)
                                       || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) {
            am.SetBool("IsWalking", true);
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)
                                      || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
            {
                am.SetBool("GoSideways", true);
            }
        }
        else if (!Input.anyKey) {
            am.SetBool("IsWalking", false);
            am.SetBool("GoSideways", false);
        }

        if (controller.isGrounded) {
            inAir = false;
            am.SetBool("IsJumping", false);
            canDash = true;
            if ((lastGrounded != 0.2f) && (onLand != null))
                onLand();
            moveDirection.y = 0f;
            lastGrounded = 0.2f;

        } else if (lastGrounded > 0) {
            if (!jumpflag) //this is for the jump orb 
            {
                lastGrounded = lastGrounded - Time.deltaTime;
            }
        }

        if (Input.GetButtonDown("Jump")) {
            tryJump = true;
        }
        if (Input.GetKeyDown("left shift")) {
            tryDash = true;
        }

    }

    // probably need to change this to fixed update but will need some debugging so im not doing it rn
    void FixedUpdate() {

        if (changeScene) {
            SceneManager.LoadScene(sc);
            changeScene = false;
        }


        yStore = moveDirection.y;
        //For animations
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));

        //normalize movedirection so you dont get double speed when moving diagonally.
        moveDirection = Vector3.ClampMagnitude(moveDirection, 1) * moveSpeed;
        moveDirection.y = yStore;





        if (lastGrounded > 0) {
            if (tryJump)
            {
                soundManager.PlaySound("jump");
                if (jumpflag)
                {
                    moveDirection.y = jumpForce; //can change this to make the orb jump higher

                } else {
                    moveDirection.y = jumpForce;
                }
                am.SetBool("IsJumping", true);
                jumpflag = false;
                lastGrounded = 0f;

                if (onJump != null)
                    onJump();
                if (!inAir) {
                    inAir = true;
                    if (onLeaveGround != null) {
                        onLeaveGround();
                    }
                }
            }
        } else {
            if (!inAir) {
                inAir = true;
                if (onLeaveGround != null) {
                    onLeaveGround();
                }

            }

        }
        tryJump = false;
        if (inAir && canDash) {
            if (tryDash)
            {
                soundManager.PlaySound("dash");
                canDash = false;
                dashTime = .4f;
                dashSpeed = 300;
                if (Input.GetAxis("Vertical") > 0) {
                    //foward
                    dashType = 0;
                } else if (Input.GetAxis("Vertical") < 0) {
                    //back
                    dashType = 1;
                } else if (Input.GetAxis("Horizontal") > 0) {
                    //right
                    dashType = 2;
                } else if (Input.GetAxis("Horizontal") < 0) {
                    //left
                    dashType = 3;
                } else {
                    //foward
                    dashType = 0;
                }
            }
        }
        tryDash = false;
        if (dashTime > 0) {
            dashSpeed *= .65f;
            switch (dashType) {
                case 0:
                    moveDirection += transform.forward * dashSpeed;
                    break;
                case 1:
                    moveDirection += -transform.forward * dashSpeed;
                    break;
                case 2:
                    moveDirection += transform.right * dashSpeed;
                    break;
                case 3:
                    moveDirection += -transform.right * dashSpeed;
                    break;
            }

            dashTime -= Time.deltaTime;
        }

        springCD -= Time.deltaTime;

        if (springJump && (springCD <= 0)) {

            moveDirection.y = jumpForce * 2.0f;
            springJump = false;
            springCD = 1.0f;
        }
        springJump = false;

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);

        controller.Move(moveDirection * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Spring") {
            springJump = true;
        } else if (other.gameObject.tag == "JumpOrb") {
            other.gameObject.SetActive(true);
            lastGrounded = 0.2f;

            jumpflag = true;
        } else if (other.gameObject.tag == "DashOrb") {
            other.gameObject.SetActive(true);
            canDash = true;
        }
    }
}
