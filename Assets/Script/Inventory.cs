using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	public static Inventory instance {set; get;}

	public bool[] isFull;
	public GameObject[] slots;

	public GameObject[] ButtonIcon;

	void Start(){
		instance = this;
	}


	public void Invent(){
		for (int i = 0; i < slots.Length; i++)
		{
			if(isFull[i] == false){
				//then we can quip
				isFull[i] = true;
				Instantiate(ButtonIcon[BuyItem.instance.iconIndex], slots[i].transform, false);
				break;
			}
		}
	}
}