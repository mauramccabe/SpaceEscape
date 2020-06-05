using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpawnObject : MonoBehaviour
{
    public GameObject toSpawn;

    void Start() {
        toSpawn.SetActive(false);


    }

    void OnTriggerEnter(Collider col) {
        toSpawn.SetActive(true);
        soundManager.PlaySound("plate");
    }
}
