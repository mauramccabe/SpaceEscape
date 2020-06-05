using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class springPressurePlate : MonoBehaviour
{
    [SerializeField]
    public GameObject spring;
    private float touched = 0;

    void OnTriggerEnter(Collider col)
    {
    	if(touched == 0)
    	{

    		touched = 1;
        	spring.transform.position = spring.transform.position + new Vector3(0, 2, 0);
            soundManager.PlaySound("plate");
    	}
    }
    void OnTriggerExit(Collider col)
    {

    	touched = 1;
    	
    }


}