using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeControler : MonoBehaviour
{

    public GameObject bridge;
    public GameObject plate1;
    public GameObject plate2;

    

    // Update is called once per frame
    void Update() {
        if ((plate1.GetComponent<TwoPressurePlates>().pressure + plate2.GetComponent<TwoPressurePlates>().pressure) > 3) {
            bridge.SetActive(true);
        }

        if ((plate1.GetComponent<TwoPressurePlates>().pressure + plate2.GetComponent<TwoPressurePlates>().pressure) < 4) {
            bridge.SetActive(false);
        }
    }
}
