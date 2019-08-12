using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	public GameObject itemToSpawn;
	Transform spawnPoint;

	void Start(){
		spawnPoint = GameObject.FindGameObjectWithTag("Guide").transform;
	}

	public void SpawnIt(){

		Instantiate(itemToSpawn, spawnPoint.position, Quaternion.identity);

	}

}