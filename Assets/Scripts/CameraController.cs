using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=h2d9Wc3Hhi0

public class CameraController : MonoBehaviour
{

    public GameObject player;

    private Vector3 offset;

    public float rotateSpeed;

    public Transform pivot;
    public Vector3 left1;
    public Vector3 right1;

    private Vector3 colisionCheck;
    private Vector3 tempPosition;
    private float rayLength;
    RaycastHit hit;

    void Start()
    {
        offset =  player.transform.position - transform.position;

        colisionCheck = transform.position - player.transform.position;
        rayLength = colisionCheck.magnitude;
        //player = SceneManager.Instance.player;

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

        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 295f)
        {
            pivot.rotation = Quaternion.Euler(295f, 0, 0);
        }

        float desiredYAgngle = player.transform.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAgngle, 0);
        transform.position = player.transform.position - (rotation * offset);

        left1 = player.transform.position - (player.transform.right * 1.3f);
        right1 = player.transform.position - (-player.transform.right * 1.3f);
        colisionCheck = (transform.position - player.transform.position); //* 1.5f;

        //prevent camera clipping through floor
        if (transform.position.y  < (player.transform.position.y + .2f))
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y + .2f, transform.position.z);
        } else 
        if (Physics.Raycast(player.transform.position, colisionCheck, out hit, rayLength) &&
                Physics.Raycast(left1, colisionCheck, rayLength) &&
                Physics.Raycast(right1, colisionCheck, rayLength)) {
            if (!(hit.collider.tag == "Player") && !(hit.collider.tag == "Box")) {
                transform.position = hit.point; //+ ((player.transform.position - hit.point) * 0.15f);
            }
        } else {
            transform.position = player.transform.position - (rotation * offset);
        }
        transform.LookAt(player.transform);
    }
}
