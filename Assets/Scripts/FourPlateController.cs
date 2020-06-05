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

    public int combinedPressure;


    void Start()
    {
        doorStart2 = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        combinedPressure = plate1_.GetComponent<FourPressurePlate>().pressure + plate2_.GetComponent<FourPressurePlate>().pressure +plate3_.GetComponent<FourPressurePlate>().pressure + plate4_.GetComponent<FourPressurePlate>().pressure;
        if ((plate1_.GetComponent<FourPressurePlate>().pressure + plate2_.GetComponent<FourPressurePlate>().pressure) + plate3_.GetComponent<FourPressurePlate>().pressure + plate4_.GetComponent<FourPressurePlate>().pressure > 6)
        {
            transform.position = doorStart2 + new Vector3(0, -400, 0);
            soundManager.PlaySound("door");
            
        }

        if ((plate1_.GetComponent<FourPressurePlate>().pressure + plate2_.GetComponent<FourPressurePlate>().pressure) + plate3_.GetComponent<FourPressurePlate>().pressure + plate4_.GetComponent<FourPressurePlate>().pressure < 7)
        
        {
            transform.position = doorStart2;
        }
    }
}
