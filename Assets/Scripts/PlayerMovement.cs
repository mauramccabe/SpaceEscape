using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public float jumpForce;
    public CharacterController controller;
    public float gravityScale;
    private Vector3 moveDirection;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        
        //normalize movedirection so you dont get double speed when moving diagonally.
        moveDirection = Vector3.ClampMagnitude(moveDirection,1) * moveSpeed;
        moveDirection.y = yStore;

        if (controller.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }
        moveDirection.y = moveDirection.y + (Physics.gravity.y  * gravityScale *Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);
    }
}
