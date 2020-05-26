using UnityEngine;
using System.Collections;



public class PickUpObject : MonoBehaviour {

	private Transform player;
	//public Transform head;
	private float distanceFromPlayer;



	public bool hasPlayer = false;
	public bool beingCarried = false;
	Rigidbody rb;
	public bool hasAnchor = false;


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
		player = SceneManager.Instance.player.transform;

		rb = GetComponent<Rigidbody>();
		killPlane = SceneManager.Instance.killPlane;
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

		if(triggerPickup && (onBoxPickup != null)) {
			onBoxPickup(gameObject);
        }
	}

	void Drop(bool triggerDrop = true) {
		rb.velocity = Vector3.zero;

		rb.isKinematic = false;
		rb.useGravity = true;
		transform.parent = null;

		beingCarried = false;
		rb.constraints = 0;
		 

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
		if (beingCarried) {
			//transform.localPosition = Vector3.SmoothDamp(transform.localPosition, desiredPosition, ref velocity, 1.0f);
			//transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(Vector3.zero), Time.time * 0.1f);
		}	
	}


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
		
	}
}