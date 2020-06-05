using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlatform : MonoBehaviour
{
    
    public GameObject platform;
    public RockMovement platformScript;
    public bool hasPlayed;

    void Awake() {
        platformScript = platform.GetComponent<RockMovement>();
        
    }


    void OnTriggerStay(Collider col) {
        platformScript.automatic = true;
        if (!hasPlayed) {
            soundManager.PlaySound("plate");
            hasPlayed = true;
        }
        
    }
    void OnTriggerExit(Collider col) {
        platformScript.automatic = false;
        hasPlayed = false;
    }

}
