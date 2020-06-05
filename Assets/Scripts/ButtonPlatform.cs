using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlatform : MonoBehaviour
{
    
    public GameObject platform;
    public RockMovement platformScript;

    void Awake() {
        platformScript = platform.GetComponent<RockMovement>();
        
    }


    void OnTriggerStay(Collider col) {
        platformScript.automatic = true;
        soundManager.PlaySound("plate");
    }
    void OnTriggerExit(Collider col) {
        platformScript.automatic = false;
    }

}
