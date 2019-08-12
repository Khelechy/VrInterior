using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance { set; get; }

	public int getBalance;

	public Text moneyBalance;
	public Animator shopAnimation;

	bool isShopClicked;

	void Start () {
		instance = this;
		getBalance = PlayerPrefs.GetInt ("FinalBalance");
	}

	void Update () {
		PlayerPrefs.SetInt ("FinalBalance", getBalance);
		getBalance = PlayerPrefs.GetInt ("FinalBalance");
		//moneyBalance.text = "Balance: " + PlayerPrefs.GetInt("FinalBalance");
		moneyBalance.text = "Balance: " + getBalance;

	}

	public void BuyItem (int amount) {
		if (getBalance >= amount) {
			getBalance -= amount;
			Debug.Log ("item bought");
			PlayerPrefs.SetInt ("FinalBalance", getBalance);
			Inventory.instance.Invent();
		}else{
			Debug.Log("Not Enough Money");
		}
	}

	public void LoadAccount () {
		getBalance += 200000;
		PlayerPrefs.SetInt ("FinalBalance", getBalance);
	}

	public void onShopClick () {
		shopAnimation.SetTrigger ("Open");
	}
	public void onShopClosedClick () {
		shopAnimation.SetTrigger ("Closed");
	}

}