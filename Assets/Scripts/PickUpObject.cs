using UnityEngine;
using System.Collections;

public class PickUpObject : MonoBehaviour {
	public Transform player;
	public GameObject boxes;

	bool hasPlayer = false;
	bool beingCarried = false;
	Rigidbody rb;
	bool hasAnchor = false;



	void OnTriggerEnter(Collider other)
	{
		rb = GetComponent<Rigidbody>();
		hasPlayer = true;

		if(other.gameObject.name == "Anchor")
		{
			hasAnchor = true;

		}
	}
	
	void OnTriggerExit(Collider other)
	{
		hasPlayer = false;
		hasAnchor = false;


	}	
	
	void Update()
	{
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