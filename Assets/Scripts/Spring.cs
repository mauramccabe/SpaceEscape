using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
   
    public float springStrength;

    public bool entered = false;

    public GameObject player;
   /*
    private void OnTriggerEnter(Collider other)
    {
      
        if (other.gameObject == player)
        {

            moveDirection.y = jumpForce * 2;
        }
        
    }*/
}
