using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour {
    // Start is called before the first frame update

    public Vector3 respawnLocation;

    
    // Update is called once per frame

    void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.tag == "Player") {
            if(respawnLocation.Equals(new Vector3(0,0,0))){
                print("Need to assign a spawnlocation to checkpoint (or you tried to use (0,0,0))");
                return; 
            }
            MySceneManager.Instance.killPlane.respawnPoint = respawnLocation;


        }
    }

}