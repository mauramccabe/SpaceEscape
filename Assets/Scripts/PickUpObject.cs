using UnityEngine;
using System.Collections;



public class PickUpObject : MonoBehaviour {
	private Transform player;


	public bool hasPlayer = false;
	public bool beingCarried = false;
	Rigidbody rb;
	bool hasAnchor = false;

	private GameObject killPlane;

    public delegate void BoxHandler(GameObject box);
	public static event BoxHandler onBoxDrop;
	public static event BoxHandler onBoxPickup;

	public Vector3 startPosition;
	public Quaternion startRotation;

	void Start() {
		startPosition = transform.position;
		startRotation = transform.rotation;
		player = SceneManager.Instance.player.transform;
		killPlane = SceneManager.Instance.killPlane;
	}





	void OnTriggerEnter(Collider other) {

		if (other.gameObject.tag == "Player") {
			rb = GetComponent<Rigidbody>();
			hasPlayer = true;
		}
       		
		if(other.gameObject.tag == "Anchor") {
			hasAnchor = true;
		}
	}  

	void OnTriggerExit(Collider other) {

		if (other.gameObject.tag == "Player") { 
			hasPlayer = false;
		}

		if (other.gameObject.tag == "Anchor") {
			hasAnchor = false;
		}

	}	
	
	void Pickup(bool triggerPickup = true) {
		rb.velocity = Vector3.zero;
		rb.isKinematic = true;
		transform.parent = player;
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

		if (triggerDrop && (onBoxDrop != null)) { 
			onBoxDrop(gameObject);
		} 
	}
	void Update() {
		if (killPlane.GetComponent<KillPlaneTrigger>().playerIsDead) { 
            if (rb && beingCarried) { 
				Drop(false);
            }	
		}

		if(beingCarried) {
			if(Input.GetKeyDown("e")) {
				Drop();
			}
			
			if(Input.GetKeyDown("e") && hasAnchor && hasPlayer) {
				rb.isKinematic = true;
				rb.useGravity = false;
				beingCarried = false;
			}
		} else {
			if(Input.GetKeyDown("e") && hasPlayer) {
				Pickup();
			}
		}
	}
}