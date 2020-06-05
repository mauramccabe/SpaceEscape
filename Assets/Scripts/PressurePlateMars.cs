using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateMars : MonoBehaviour
{
    [SerializeField]
    GameObject door;

    public float height;

    void OnTriggerEnter(Collider col)
    {
        door.transform.position = door.transform.position + new Vector3(0, -height, 0);
        soundManager.PlaySound("plate");
    }
    void OnTriggerExit(Collider col)
    {
        door.transform.position = door.transform.position + new Vector3(0, height, 0);
    }
}
