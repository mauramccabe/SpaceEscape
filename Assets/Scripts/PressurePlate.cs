using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField]
    GameObject door;
    public Vector3 up;
    public Vector3 down;
    int pressure = 0;
    bool hasPlayed = false;
    void OnTriggerEnter(Collider col)
    {
        door.transform.position = door.transform.position + up;
        pressure++;
    }
    void OnTriggerExit(Collider col)
    {
        door.transform.position = door.transform.position + down;
        pressure--;
    }

    void Update() {
        if (pressure > 1 && !hasPlayed) {
            soundManager.PlaySound("door");
            hasPlayed = true;
        }
        if (pressure < 1) {
            hasPlayed = false;
        }
    }
}