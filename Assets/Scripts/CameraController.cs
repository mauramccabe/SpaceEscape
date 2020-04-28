using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;

    private Vector3 offset;

    public float rotateSpeed;

    public Transform pivot;

    void Start()
    {
        offset =  player.transform.position - transform.position;
        
        
        
        //place pivot on top of player
        pivot.transform.position = player.transform.position;
        //make pivot a child of player
        pivot.transform.parent = player.transform;

        //lock mouse
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void LateUpdate()
    {
        //get x position of mouse and rotate the player
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        player.transform.Rotate(0, horizontal, 0);


        //get y position of mouse and rotate the pivot
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        pivot.transform.Rotate(-vertical, 0, 0);


        if(pivot.rotation.eulerAngles.x > 45f && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(45f, 0, 0);
        }

        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 315f)
        {
            pivot.rotation = Quaternion.Euler(315f, 0, 0);
        }

        float desiredYAgngle = player.transform.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAgngle, 0);
        transform.position = player.transform.position - (rotation * offset);


        //prevent camera clipping through floor

        if(transform.position.y < player.transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y - .5f, transform.position.z);
        }
        transform.LookAt(player.transform);
    }
}
