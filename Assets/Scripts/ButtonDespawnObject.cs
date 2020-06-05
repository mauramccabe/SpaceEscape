using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDespawnObject : MonoBehaviour
{

    public GameObject toDeSpawn;

    void OnTriggerEnter(Collider col) {
        toDeSpawn.SetActive(false);
        soundManager.PlaySound("plate");
    }
   
}
