using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPressurePlate : MonoBehaviour
{
    [SerializeField]
    GameObject door;
    int pressure = 0;
    bool hasPlayed = false;
    void OnTriggerEnter(Collider col)
    {
        door.transform.position = door.transform.position + new Vector3(0, 5, 0);
        pressure++;
    }
    void OnTriggerExit(Collider col)
    {
        door.transform.position = door.transform.position + new Vector3(0, -5, 0);
        pressure--;
    }
    void Update() {
        if(pressure > 1 && !hasPlayed) {
            soundManager.PlaySound("door");  
            hasPlayed = true;
        }
        if( pressure < 1) {
            hasPlayed = false;
        }
    }
}
