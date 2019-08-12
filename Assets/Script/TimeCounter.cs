using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour {

	public float startSessionCounter = 60.0f;
	private float sessionCounter;

	public Text counterText;

	public float minutes, seconds;

	void Start () {
		sessionCounter = startSessionCounter;

	}

	void Update () {
		sessionCounter -= Time.deltaTime;
		if (sessionCounter <= 0) {
			sessionCounter = 0.0f;
		}
		//counterText.text = ((int) sessionCounter).ToString ();

	}

}