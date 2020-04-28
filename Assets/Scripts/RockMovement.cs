using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
// http://www.donovankeith.com/2016/05/making-objects-float-up-down-in-unity/
public class RockMovement : MonoBehaviour
{
    public float degrees;
    public float height;
    public float frequency;

    Vector3 position = new Vector3();
    Vector3 temp = new Vector3();

    void Start()
    {
        position = transform.position;
    }
    void Update()
    {
        transform.Rotate(new Vector3(0f, Time.deltaTime * degrees, 0f), Space.World);

        temp = position;
        temp.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * height;
        transform.position = temp;
    }
}


