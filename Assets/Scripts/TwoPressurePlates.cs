using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPressurePlates : MonoBehaviour
{
    [SerializeField]
    GameObject door;
    int plates = 0;
    void Update()
    {
        if (plates == 3)
        {
            door.transform.position = door.transform.position + new Vector3(0, -4, 0);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        plates = plates + 1;
    }
    void OnTriggerExit(Collider col)
    {
        plates = plates - 1;
    }
}
