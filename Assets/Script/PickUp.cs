using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

	public Transform player;

	public GameObject pickPanel;
	public Transform playerCam;
	public float throwForce = 10;
	bool canCarry = false;
	bool beingCarried = false;
	private bool touched = false;

	void Update () {
		float dist = Vector3.Distance (gameObject.transform.position, player.position);
		if (dist <= 10.5f) {
			canCarry = true;
			pickPanel.SetActive (true);
		} else {
			pickPanel.SetActive (false);
			canCarry = false;
		}
		if (canCarry && Input.GetButtonDown ("Fire1")) {
			GetComponent<Rigidbody> ().isKinematic = false;
			GetComponent<Rigidbody> ().useGravity = false;
			transform.parent = playerCam;
			this.transform.position = playerCam.position;
			pickPanel.SetActive (false);
			beingCarried = true;
			Debug.Log ("Carrying");
		}
		if (beingCarried) {
			pickPanel.SetActive (false);
		}
		if (beingCarried && Input.GetKey (KeyCode.D)) {
			GetComponent<Rigidbody> ().isKinematic = false;
			GetComponent<Rigidbody> ().useGravity = true;
			transform.parent = null;
			this.transform.position = transform.position;
			beingCarried = false;
			Debug.Log ("Dropped");
		}

		if(Input.GetKeyDown(KeyCode.R)){
			RotateObjects();
		}

	}

	void OnTriggerEnter () {
		if (beingCarried) {
			GetComponent<Rigidbody> ().isKinematic = false;
			GetComponent<Rigidbody> ().useGravity = false;
			transform.parent = playerCam;
			this.transform.position = playerCam.position;
			beingCarried = true;
			Debug.Log ("Carrying");
		}
	}

	public void RotateObjects(){
		if(beingCarried){
			transform.Rotate(0, 10 * Time.deltaTime * throwForce, 0);
		}
	}

}