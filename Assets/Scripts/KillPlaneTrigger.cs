using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlaneTrigger : MonoBehaviour {

    public Vector3 respawnPoint;
    public bool playerIsDead = false;


    public delegate void DeathHandler();
    public static event DeathHandler onDeath;


    void OnTriggerEnter (Collider other) {
        
        if (other.gameObject.tag == "Player")
        {
            soundManager.PlaySound("respawn");
            playerIsDead = true;

        }

        if(other.gameObject.tag == "Box") {
            print("box respawned");
            other.GetComponent<PickUpObject>().Drop();
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            other.transform.position = other.GetComponent<PickUpObject>().startPosition;
            other.transform.rotation = other.GetComponent<PickUpObject>().startRotation;
            Physics.SyncTransforms();

        }
    }

    void LateUpdate() {
        if (playerIsDead) {
            Respawn();
        }
    }

    void Respawn() {
        MySceneManager.Instance.player.transform.position = respawnPoint;
        playerIsDead = false;
        Physics.SyncTransforms();
        if (onDeath != null) {
            onDeath();
        }
    }
}
