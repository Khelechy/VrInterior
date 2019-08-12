using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour {

	public GameObject pickItem;
	public GameObject tempParent;
	public Transform guide;
	public GameObject pivot;
	Transform player;

	public float pushForce = 100.0f;

	public GameObject originalParent;

	private Vector3 dragOffset;

	private float mCoord;

	bool canPick = false;
	bool isCarried = false;

	bool CanPush = false;
	float rFactor = 0.0f;

	public GameObject pickInfo;

	public float dist;

	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player").transform;
		pickItem.GetComponent<Rigidbody> ().useGravity = true;
		mCoord = Camera.main.WorldToScreenPoint (pickItem.transform.position).z;
		//pickInfo = GameObject.FindGameObjectWithTag ("PickInfo");

	}

	void Update () {

		if (tempParent == null || guide == null || pickInfo == null) {
			tempParent = GameObject.FindGameObjectWithTag ("Guide");
			guide = GameObject.FindGameObjectWithTag ("Guide").transform;
			pickInfo = GameObject.FindGameObjectWithTag ("PickInfo");
		}

		dist = Vector3.Distance (pickItem.transform.position, player.position);
		if (dist < 10) {
			pickInfo.SetActive (true);
		} else {
			pickInfo.SetActive (false);
		}
		//Debug.Log (dist);

		//RayCasting

		int sx = Screen.width / 2;
		int sy = Screen.height / 2;

		Ray ray = Camera.main.ScreenPointToRay (new Vector3 (sx, sy));
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider.tag == "Pickable") {
				CanPush = true;
				Debug.Log ("You can Carry");
			}else{
				CanPush = false;
			}

		}

		
		
		//DRAG Objects

		//PICK AND DROP

		/*if (Input.GetKey (KeyCode.C)) {
			PickUp ();
			Debug.Log ("Picked");
		}

		if (Input.GetKeyUp (KeyCode.C)) {
			DropDown ();
			Debug.Log ("Dropped");
		} */

		//PUSH OBJECTS
		/*if (CanPush && Input.GetKey (KeyCode.P)) {
			PushItem ();
		} */

		//ROTATE OBJECTS

		if (Input.GetKey (KeyCode.R) && CanPush == true) {
			rFactor = 5.0f;
			RotateObject ();
		}

		if (Input.GetKey (KeyCode.T) && CanPush == true) {
			rFactor = -5.0f;
			RotateObject ();
		}

		pickItem.GetComponent<Rigidbody> ().useGravity = true;
		pickItem.GetComponent<Rigidbody> ().isKinematic = false;

	}

	void RotateObject () {
		pickItem.GetComponent<Rigidbody> ().useGravity = false;
		pickItem.GetComponent<Rigidbody> ().isKinematic = true;
		//pickItem.transform.parent = pivot.transform;
		pivot.transform.Rotate (0, rFactor, 0);

	}

	void PushItem () {
		pickItem.GetComponent<Rigidbody> ().useGravity = true;
		pickItem.GetComponent<Rigidbody> ().isKinematic = false;
		pickItem.GetComponent<Rigidbody> ().AddForce (transform.forward * pushForce);
	}

	void OnMouseDown () {

		pickItem.GetComponent<Rigidbody> ().useGravity = true;
		pickItem.GetComponent<Rigidbody> ().isKinematic = false;

		dragOffset = pickItem.transform.position - GetMouseWorldPos ();

	}

	private Vector3 GetMouseWorldPos () {
		Vector3 mousePoint = Input.mousePosition;
		mousePoint.z = mCoord;
		pickItem.GetComponent<Rigidbody> ().useGravity = true;
		pickItem.GetComponent<Rigidbody> ().isKinematic = false;

		return Camera.main.ScreenToWorldPoint (mousePoint);

	}

	void OnMouseDrag () {

		pickItem.GetComponent<Rigidbody> ().useGravity = true;
		pickItem.GetComponent<Rigidbody> ().isKinematic = false;
		pickItem.GetComponent<BoxCollider> ().enabled = true;
		transform.position = GetMouseWorldPos () + dragOffset;

	}

	/*void PickUp () {

		pickItem.GetComponent<Rigidbody> ().useGravity = false;
		pickItem.GetComponent<Rigidbody> ().isKinematic = true;
		pickItem.GetComponent<BoxCollider> ().enabled = false;
		pickItem.transform.position = guide.transform.position;
		pickItem.transform.parent = tempParent.transform;
		isCarried = true;

	}

	void DropDown () {

		pickItem.GetComponent<Rigidbody> ().useGravity = true;
		pickItem.GetComponent<Rigidbody> ().isKinematic = false;
		pickItem.GetComponent<BoxCollider> ().enabled = true;
		pickItem.transform.position = tempParent.transform.position;
		pickItem.transform.parent = originalParent.transform;
		isCarried = false;

	}
 */

}