using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlaneTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Vector3 respawnPoint;
    bool playerIsDead = false;
    
    

    void OnTriggerEnter (Collider other)
    {
        
        if (other.gameObject == player)
        {
            playerIsDead = true;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsDead)
        {
            
            Respawn();
        }
    }

    void Respawn()
    {
        player.transform.position = respawnPoint;
        playerIsDead = false;
        Physics.SyncTransforms();
    }
}
