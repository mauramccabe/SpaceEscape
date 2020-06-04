using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourPressurePlates : MonoBehaviour
{
   
    public int pressure = 0;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Box")
        {
            
            pressure = pressure + 1;
            
        }
        if (other.gameObject.tag == "Player")
        {         
            pressure = pressure + 4;
            
        }



    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Box")
        {
            
            pressure = pressure - 1;
          
        }
        if (other.gameObject.tag == "Player")
        {
            
            pressure = pressure - 4;
            
        }


    }
}