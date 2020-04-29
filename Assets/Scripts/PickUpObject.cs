using UnityEngine;
using System.Collections;

public class PickUpObject : MonoBehaviour {
	public Transform player;


	public bool hasPlayer = false;
	public bool beingCarried = false;
	Rigidbody rb;
	bool hasAnchor = false;

	public GameObject killPlane;



	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			rb = GetComponent<Rigidbody>();
			hasPlayer = true;
		}
       
			
		
		if(other.gameObject.tag == "Anchor")
		{
			hasAnchor = true;

		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{ 
			hasPlayer = false;

		}
		if (other.gameObject.tag == "Anchor")
		{
			
			hasAnchor = false;
		}

	}	
	
	
	void Update()
	{
		if (killPlane.GetComponent<KillPlaneTrigger>().playerIsDead)
        {
            if (rb)
            {
				rb.velocity = Vector3.zero;
				rb.isKinematic = false;
				rb.useGravity = true;
				transform.parent = null;

				beingCarried = false;
            }
			
		}


		if(beingCarried)
		{
			if(Input.GetKeyDown("e"))
			{
				rb.velocity = Vector3.zero;
				rb.isKinematic = false;
				rb.useGravity = true;
				transform.parent = null;
				
				beingCarried = false;

			}
			
			if(Input.GetKeyDown("e") && hasAnchor && hasPlayer)
			{
				rb.isKinematic = true;
				
				rb.useGravity = false;

				beingCarried = false;
				
			}
		}
		else
		{
			if(Input.GetKeyDown("e") && hasPlayer)
			{
				rb.velocity = Vector3.zero;
				rb.isKinematic = true;
				transform.parent = player;
				beingCarried = true;
			}
		

		}
	}
}