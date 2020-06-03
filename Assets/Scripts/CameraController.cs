using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=h2d9Wc3Hhi0

public class CameraController : MonoBehaviour
{

    public GameObject player;
    public GameObject cameraLookAt;
    private Vector3 offset;

    public float rotateSpeed;

    public Transform pivot;
    public Vector3 left1;
    public Vector3 right1;

    private Vector3 colisionDirection;
    private Vector3 rightColisionDirection;
    private Vector3 leftColisionDirection;
    private Vector3 tempPosition;
    public float rayLength;
    public double timeCameraIsColliding = 0.0d;
    public bool leftHit;
    public bool centerHit;
    public bool rightHit;
    RaycastHit hit;
    RaycastHit hit1;
    RaycastHit hit2;

    private Vector3 colisionPoint;
    private float t;
    private Vector3 hitPoint;
    private float r;

    void Start()
    {
        offset = player.transform.position - transform.position;


        //ug math hard
        t = 1.2f;
        colisionPoint = new Vector3((1 - t) * cameraLookAt.transform.position.x + t * transform.position.x,
            (1 - t) * cameraLookAt.transform.position.y + t * transform.position.y, (1 - t) * cameraLookAt.transform.position.z + t * transform.position.z);
        
            
        colisionDirection = colisionPoint - cameraLookAt.transform.position;

        rayLength = colisionDirection.magnitude;



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


       


        left1 = (cameraLookAt.transform.position - (cameraLookAt.transform.right * .69f)) + (cameraLookAt.transform.up *-1.1f);
        right1 = (cameraLookAt.transform.position - (-cameraLookAt.transform.right * .69f)) + (cameraLookAt.transform.up *-1.1f);

        colisionPoint = new Vector3((1 - t) * cameraLookAt.transform.position.x + t * transform.position.x,
           (1 - t) * cameraLookAt.transform.position.y + t * transform.position.y, (1 - t) * cameraLookAt.transform.position.z + t * transform.position.z);

        colisionDirection = colisionPoint - cameraLookAt.transform.position;
        leftColisionDirection = colisionPoint - left1;
        rightColisionDirection = colisionPoint - right1;

        
        centerHit = Physics.Raycast(cameraLookAt.transform.position, colisionDirection, out hit, rayLength);
        leftHit = Physics.Raycast(left1, leftColisionDirection,out hit1, rayLength);
        rightHit = Physics.Raycast(right1, rightColisionDirection,out hit2, rayLength);
        if (centerHit) {
            Debug.DrawRay(cameraLookAt.transform.position, colisionDirection.normalized *hit.distance , Color.yellow);
        }
        if (leftHit) {
            Debug.DrawRay(left1, leftColisionDirection.normalized *hit1.distance , Color.yellow);
        }
        if (rightHit) {
            Debug.DrawRay(right1, rightColisionDirection.normalized *hit2.distance , Color.yellow);
        }


        if (centerHit && leftHit && rightHit) {
            timeCameraIsColliding += Time.deltaTime;

            r = 1.0f / 1.2f;
            hitPoint = new Vector3((1 - r) * cameraLookAt.transform.position.x + r * hit.point.x,
        (1 - r) * cameraLookAt.transform.position.y + r * hit.point.y, (1 - r) * cameraLookAt.transform.position.z + r * hit.point.z);

            transform.position = hitPoint; 
               
        } else {
            transform.position = player.transform.position - (rotation * offset);
            timeCameraIsColliding = 0.0d;
        }
        
        transform.LookAt(cameraLookAt.transform);
    }
}
