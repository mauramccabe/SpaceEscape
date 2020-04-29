using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlaneTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject box1;
    public GameObject box2;
    public GameObject box3;

    public Transform box1Transform;
    public Transform box2Transform;
    public Transform box3Transform;

    private Vector3 box1Position;
    private Quaternion box1Rotation;

    private Vector3 box2Position;
    private Quaternion box2Rotation;
            
    private Vector3 box3Position;
    private Quaternion box3Rotation;

    public GameObject player;
    public Vector3 respawnPoint;
    public bool playerIsDead = false;
    
    void Start()
    {
        box1Position = box1Transform.position;
        box1Rotation = box1Transform.rotation;

        box2Position = box2Transform.position;
        box2Rotation = box2Transform.rotation;

        box3Position = box3Transform.position;
        box3Rotation = box3Transform.rotation;
    }

    void OnTriggerEnter (Collider other)
    {
        
        if (other.gameObject == player)
        {
            playerIsDead = true;

        }

        if(other.gameObject == box1)
        {
            box1.GetComponent<Rigidbody>().velocity = Vector3.zero;
            box1.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            box1.transform.position = box1Position;
            box1.transform.rotation = box1Rotation;
            Physics.SyncTransforms();

        }

        if (other.gameObject == box2)
        {
            box2.GetComponent<Rigidbody>().velocity = Vector3.zero;
            box2.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            box2.transform.position = box2Position;
            box2.transform.rotation = box2Rotation;
            Physics.SyncTransforms();

        }

        if (other.gameObject == box3)
        {
            box3.GetComponent<Rigidbody>().velocity = Vector3.zero;
            box3.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            box3.transform.position = box3Position;
            box3.transform.rotation = box3Rotation;
            Physics.SyncTransforms();

        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (playerIsDead)
        {
            
            Respawn();
        }
    }

    void Respawn()
    {
        player.transform.position = respawnPoint;
        playerIsDead = false;
        Physics.SyncTransforms();
    }


}
