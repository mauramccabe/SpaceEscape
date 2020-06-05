using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbScript : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        PlayerMovement.onLand += Respawn;
    }

    // Update is called once per frame
    void Respawn() {
        this.gameObject.SetActive(true);
    }

}
