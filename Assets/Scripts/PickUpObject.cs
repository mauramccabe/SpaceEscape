using UnityEngine;
using System.Collections;



public class PickUpObject : MonoBehaviour {

	private Transform player;
	public float distanceFromPlayer;



	public bool hasPlayer = false;
	public bool beingCarried = false;
	Rigidbody rb;
	public bool hasAnchor = false;
	Animator amin;


	private KillPlaneTrigger killPlane;

    public delegate void BoxHandler(GameObject box);
	public static event BoxHandler onBoxDrop;
	public static event BoxHandler onBoxPickup;

	public Vector3 startPosition;
	public Quaternion startRotation;

	private Vector3 desiredPosition = new Vector3(0f, 0.0905f, 0f);
	private Vector3 velocity = Vector3.zero;

	void Start() {
		startPosition = transform.position;
		startRotation = transform.rotation;
		player = MySceneManager.Instance.player.transform;


		rb = GetComponent<Rigidbody>();
		amin = player.GetComponent<Animator>();
		killPlane = MySceneManager.Instance.killPlane;
	}


	void OnTriggerEnter(Collider other) {

		if (other.gameObject.tag == "PlayerTrigger") {
			
			hasPlayer = true;
		}
       		
		if(other.gameObject.tag == "Anchor") {
			hasAnchor = true;
		}

	}  

	void OnTriggerExit(Collider other) {

		if (other.gameObject.tag == "PlayerTrigger") { 
			hasPlayer = false;
		}

		if (other.gameObject.tag == "Anchor") {
			hasAnchor = false;
		}

	}	
	
	void Pickup(bool triggerPickup = true) {

		soundManager.PlaySound("box");

		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		rb.isKinematic = false;

		rb.useGravity = false;
		transform.parent = player;
		//transform.position = head.position;

		//why does this work this way i am so confused.....
		//why is the local position scaled so much. 0.1 translates to like 1 unit for some reason.
		transform.localPosition = desiredPosition;
		transform.rotation = Quaternion.Euler(Vector3.zero);
		rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX |
			RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
		beingCarried = true;
       
        if (triggerPickup && (onBoxPickup != null)) {
			onBoxPickup(gameObject);
        }
	}

	public void Drop(bool triggerDrop = true) {
		rb.velocity = Vector3.zero;

		rb.isKinematic = false;
		rb.useGravity = true;
		transform.parent = null;

		beingCarried = false;
        rb.constraints = 0;
		rb.transform.localScale = new Vector3(2f, 2f, 2f);

		if (triggerDrop && (onBoxDrop != null)) { 
			onBoxDrop(gameObject);
		}
	}

	
	void Anchor() {
		rb.isKinematic = true;
		rb.useGravity = false;
		beingCarried = false;
	}

	void FixedUpdate() {
		
		
		distanceFromPlayer = Vector3.Distance(player.position, transform.position);


		if (killPlane.playerIsDead) {
			if (rb && beingCarried) {
				Drop(false);
				amin.SetBool("HasBox", false);
			}
		}

		if (beingCarried) {
			
			if (Input.GetKeyDown("e"))
			{
				Drop();
				amin.SetBool("HasBox", false);
			}

			if (distanceFromPlayer > 2.1f)
			{
				Drop();
				amin.SetBool("HasBox", false);
			}

			if (Input.GetKeyDown("e") && hasAnchor)
			{
				Anchor();
				amin.SetBool("HasBox", false);
			}

		} else if (Input.GetKeyDown("e") && hasPlayer)
		{
			Pickup();
			amin.SetBool("HasBox", true);
		}

		if (beingCarried) {
			if(transform.localPosition.x > .077) {
				transform.localPosition = new Vector3(.077f, transform.localPosition.y, transform.localPosition.z);
				rb.velocity = Vector3.zero;
			}
			if (transform.localPosition.x < -.077) {
				transform.localPosition = new Vector3(-.077f, transform.localPosition.y, transform.localPosition.z);
				rb.velocity = Vector3.zero;
			}
			if (transform.localPosition.z > .077) {
				transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, .077f);
				rb.velocity = Vector3.zero;
			}
			if (transform.localPosition.z < -.077) {
				transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -.077f);
				rb.velocity = Vector3.zero;
			}

			transform.localPosition = Vector3.SmoothDamp(transform.localPosition, desiredPosition, ref velocity, 1.0f);
			transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(Vector3.zero), Time.time * 0.1f);
		}	
	}

	/*
	void Update() {

		distanceFromPlayer = Vector3.Distance(player.position, transform.position);


		if (killPlane.playerIsDead) { 
            if (rb && beingCarried) { 
				Drop(false);
            }	
		}

		if(beingCarried) {
			
			if (Input.GetKeyDown("e")) {
				Drop();
			}

			if(distanceFromPlayer > 2) {
				Drop();
			}

			if(Input.GetKeyDown("e") && hasAnchor) {
				Anchor();
			}


		} else if(Input.GetKeyDown("e") && hasPlayer) {
				
				Pickup();
		}
		
	}*/
}