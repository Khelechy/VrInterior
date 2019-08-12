using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LaunchManager : MonoBehaviour {

	public GameObject LaunchButton;

	public void LoadVr () {
		SceneManager.LoadScene ("Real");
	}

	IEnumerator Start () {
		LaunchButton.SetActive(false);

		yield return new WaitForSeconds (4.0f);
		Shower();
	}

	public void Shower () {
		LaunchButton.SetActive (true);
	}
}