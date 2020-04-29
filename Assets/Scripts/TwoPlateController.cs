using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPlateController : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 doorStart;
    public GameObject plate1;
    public GameObject plate2;

    void Start()
    {
        doorStart = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if ((plate1.GetComponent<TwoPressurePlates>().pressure + plate2.GetComponent<TwoPressurePlates>().pressure) > 3)
        {
            transform.position = doorStart + new Vector3(0, -4, 0);
        }

        if ((plate1.GetComponent<TwoPressurePlates>().pressure + plate2.GetComponent<TwoPressurePlates>().pressure) < 4)
        {
            transform.position = doorStart;
        }
    }
}
