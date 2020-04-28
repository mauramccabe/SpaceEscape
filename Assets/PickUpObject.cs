using UnityEngine;
using System.Collections;

public class PickUpObject : MonoBehaviour {
	public Transform player;

	bool hasPlayer = false;
	bool beingCarried = false;
	Rigidbody rb;



	void OnTriggerEnter(Collider other)
	{
		rb = GetComponent<Rigidbody>();
		print("test");
		hasPlayer = true;
	}
	
	void OnTriggerExit(Collider other)
	{
		hasPlayer = false;
	}	
	
	void Update()
	{
		if(beingCarried)
		{
			if(Input.GetKeyDown("k"))
			{
				rb.isKinematic = false;
				transform.parent = null;
				beingCarried = false;

			}
		}
		else
		{
			if(Input.GetKeyDown("k") && hasPlayer)
			{
				rb.isKinematic = true;
				transform.parent = player;
				beingCarried = true;
			}
		}
	}
}