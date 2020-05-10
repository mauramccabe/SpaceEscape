﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlaneTrigger : MonoBehaviour {

    public Vector3 respawnPoint;
    public bool playerIsDead = false;
    

    void OnTriggerEnter (Collider other) {
        
        if (other.gameObject.tag == "Player") {
            playerIsDead = true;

        }

        if(other.gameObject.tag == "Box") {
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
        SceneManager.Instance.player.transform.position = respawnPoint;
        playerIsDead = false;
        Physics.SyncTransforms();
    }
}
