using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPressurePlate : MonoBehaviour
{
    [SerializeField]
    public GameObject rock;
    public GameObject rock2;
    public GameObject rock3;
    private float touched = 0;

    void OnTriggerEnter(Collider col)
    {
    	if(touched == 0)
    	{

    		touched = 1;
        	rock.transform.position = rock.transform.position + new Vector3(0, 34, 0);
        	rock2.transform.position = rock2.transform.position + new Vector3(0, 34, 0);
        	rock3.transform.position = rock3.transform.position + new Vector3(0, 34, 0);
            soundManager.PlaySound("door");
    	}
    }
    void OnTriggerExit(Collider col)
    {

    	touched = 1;
    	
    }


}