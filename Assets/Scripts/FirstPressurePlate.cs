using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPressurePlate : MonoBehaviour
{
    [SerializeField]
    GameObject door;

    void OnTriggerEnter(Collider col)
    {
        door.transform.position = door.transform.position + new Vector3(0, 5, 0);
        soundManager.PlaySound("plate");
    }
    void OnTriggerExit(Collider col)
    {
        door.transform.position = door.transform.position + new Vector3(0, -5, 0);
    }
}
