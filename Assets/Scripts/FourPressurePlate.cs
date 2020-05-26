using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourPressurePlate : MonoBehaviour
{
   

	[SerializeField]
    GameObject door;
    public int pressure = 0;
    public float height;


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
        if(pressure == 4)
        {
        	door.transform.position = door.transform.position + new Vector3(0, -height, 0);
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
        if(pressure < 4)
        {
        	door.transform.position = door.transform.position + new Vector3(0, height, 0);

        }


    }
    void update()
    {
    	if(pressure == 4)
    	{
    		door.transform.position = door.transform.position + new Vector3(0, -height, 0);
    	}
    	else
    	{
    		door.transform.position = door.transform.position + new Vector3(0, height, 0);
    	}
    }
}