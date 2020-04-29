using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField]
    GameObject door;

    void OnTriggerEnter(Collider col)
    {
        door.transform.position = door.transform.position + new Vector3(0, -4, 0);
    }
    void OnTriggerExit(Collider col)
    {
        door.transform.position = door.transform.position + new Vector3(0, 4, 0);
    }
}