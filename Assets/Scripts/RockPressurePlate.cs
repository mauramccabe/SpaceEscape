using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPressurePlate : MonoBehaviour
{
    [SerializeField]
    public GameObject rock;
    public GameObject rock2;
    private float touched = 0;

    void OnTriggerEnter(Collider col)
    {
    	if(touched == 0)
    	{

    		touched = 1;
        	rock.transform.position = rock.transform.position + new Vector3(0, 25, 0);
        	rock2.transform.position = rock2.transform.position + new Vector3(0, 25, 0);
    	}
    }
    void OnTriggerExit(Collider col)
    {

    	touched = 1;
    	
    }


}