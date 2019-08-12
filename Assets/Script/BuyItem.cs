using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItem : MonoBehaviour {

	public static BuyItem instance { set; get; }

	public int damount;
	public int iconIndex;

	int moneyNah;

	void Start () {
		instance = this;
	}

	public void BuyChair () {
		damount = 30000;
		iconIndex = 0;
		Debug.Log ("want to buy");
		GameManager.instance.BuyItem (damount);
	}

	public void BuyVase () {
		damount = 30000;
		iconIndex = 1;
		Debug.Log ("want to buy");
		GameManager.instance.BuyItem (damount);
	}

	public void BuySofa () {
		damount = 30000;
		iconIndex = 2;
		Debug.Log ("want to buy");
		GameManager.instance.BuyItem (damount);
	}

	public void BuyTable () {
		damount = 30000;
		iconIndex = 3;
		Debug.Log ("want to buy");
		GameManager.instance.BuyItem (damount);
	}

}