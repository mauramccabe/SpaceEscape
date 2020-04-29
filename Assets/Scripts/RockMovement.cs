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

    void Start()
    {
        position = transform.position;

        if (points.Length > 0)
        {
            currentTarget = points[0];
        }
        tolerance = speed * Time.deltaTime;
    }
    void Update()
    {
        if (transform.position != currentTarget)
        {
            MovePlatform();
        }
        else
        {
            UpdateTarget();
        }



        
        transform.Rotate(new Vector3(0f, Time.deltaTime * degrees, 0f), Space.World);
        /*
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
        other.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
}


