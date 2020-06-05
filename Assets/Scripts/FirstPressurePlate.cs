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
<<<<<<< HEAD
        door.transform.position = door.transform.position + new Vector3(0, 5, 0);
        soundManager.PlaySound("door");
=======
        door.transform.position = door.transform.position + new Vector3(0, 5, 0); 
        pressure++;
>>>>>>> dd107a0315c43829e3b83c7ab05961f5ecbab0e5
    }
    void OnTriggerExit(Collider col)
    {
        door.transform.position = door.transform.position + new Vector3(0, -5, 0);
        pressure--;
    }
    void Update() {
        if(pressure > 1 && !hasPlayed) {
            soundManager.PlaySound("plate");
            hasPlayed = true;
        }
        if( pressure < 1) {
            hasPlayed = false;
        }
    }
}
