using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField]
    GameObject door;
    public Vector3 up;
    public Vector3 down;

    void OnTriggerEnter(Collider col)
    {
        door.transform.position = door.transform.position + up;
        soundManager.PlaySound("plate");
    }
    void OnTriggerExit(Collider col)
    {
        door.transform.position = door.transform.position + down;
    }
}