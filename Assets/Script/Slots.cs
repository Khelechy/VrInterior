using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slots : MonoBehaviour {

	public int i;

	void Update(){
		if(transform.childCount <= 0){
			Inventory.instance.isFull[i] = false;
		}
	}

	public void LaunchItem(){
		foreach(Transform child in transform){
			child.GetComponent<Spawn>().SpawnIt();
			GameObject.Destroy(child.gameObject);
		}
	}
}
