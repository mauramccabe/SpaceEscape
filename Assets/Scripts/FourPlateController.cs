using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourPlateController : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 doorStart2;
    public GameObject plate1_;
    public GameObject plate2_;
    public GameObject plate3_;
    public GameObject plate4_;




    void Start()
    {
        doorStart2 = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if ((plate1_.GetComponent<FourPressurePlates>().pressure + plate2_.GetComponent<FourPressurePlates>().pressure) + plate3_.GetComponent<TwoPressurePlates>().pressure + plate4_.GetComponent<TwoPressurePlates>().pressure > 4)
        {
            transform.position = doorStart2 + new Vector3(0, -400, 0);
        }

        if ((plate1_.GetComponent<TwoPressurePlates>().pressure + plate2_.GetComponent<TwoPressurePlates>().pressure) + plate3_.GetComponent<TwoPressurePlates>().pressure + plate4_.GetComponent<TwoPressurePlates>().pressure < 4)
        
        {
            transform.position = doorStart2;
        }
    }
}
