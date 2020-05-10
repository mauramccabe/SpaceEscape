using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
// http://www.donovankeith.com/2016/05/making-objects-float-up-down-in-unity/
// https://www.youtube.com/watch?time_continue=254&v=9KdY4mafG_E&feature=emb_logo

public class RockMovement : MonoBehaviour
{
    public float degrees;
    public float height;
    public float frequency;

    public Vector3[] points;
    private int pointNumber = 0;
    private Vector3 currentTarget;

    public float tolerance;
    public float speed;
    public float delayTime;

    private float delayStart;

    public bool automatic;

    Vector3 position = new Vector3();
    Vector3 temp = new Vector3();

    private List<GameObject> boxesInside = new List<GameObject>();
    private bool playerIsInside = false;
    private bool playerIsChild = false;

    void Start()
    {
        PickUpObject.onBoxDrop += MakeBoxChild;
        PlayerMovement.onJump += RemovePlayerChild;
        PlayerMovement.onLand += MakePlayerChild;
        

        position = transform.position;

        if (points.Length > 0)
        {
            currentTarget = points[0];
        }
        tolerance = speed * Time.deltaTime;
    }
    void FixedUpdate()
    {
        if (transform.position != currentTarget)
        {
            MovePlatform();
        }
        else
        {
            UpdateTarget();
        }



        //commented out rocks rotating because it  broke stuff.
        /*
        transform.Rotate(new Vector3(0f, Time.deltaTime * degrees, 0f), Space.World);

        temp = position;
        temp.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * height;
        transform.position = temp;
        */
    }

    void MovePlatform()
    {
        Vector3 heading = currentTarget - transform.position;
        transform.position += (heading / heading.magnitude) * speed * Time.deltaTime;
        if (heading.magnitude < tolerance)
        {
            transform.position = currentTarget;
            delayStart = Time.time;
        }
    }

    void UpdateTarget()
    {
        if (automatic)
        {
            if (Time.time - delayStart > delayTime)
            {
                NextPlatform();
            }
        }
    }

    public void NextPlatform()
    {
        pointNumber++;
        if (pointNumber >= points.Length)
        {
            pointNumber = 0;
        }
        currentTarget = points[pointNumber];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Box") {
            if (!boxesInside.Contains(other.gameObject))
                boxesInside.Add(other.gameObject);
        }

        if (other.gameObject.tag == "Player") {
            playerIsInside = true;
        }
     
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerIsInside = false;
        }
        if (other.gameObject.tag == "Box")
        {
            if(boxesInside.Contains(other.gameObject))
                boxesInside.Remove(other.gameObject);
        }
    }
    
    private void MakePlayerChild() {
        if (playerIsInside) {
            SceneManager.Instance.player.transform.parent = transform;
            playerIsChild = true;
        }
    }

    private void RemovePlayerChild() {
        if (playerIsChild) {
            SceneManager.Instance.player.transform.parent = null;
        }
    }

    private void MakeBoxChild(GameObject box)
    {
        if(boxesInside.Contains(box.gameObject))
            box.transform.parent = transform;
    }
}


