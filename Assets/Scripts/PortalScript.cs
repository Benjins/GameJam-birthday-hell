using UnityEngine;
using System.Collections;

public class PortalScript : MonoBehaviour {

	public bool BrettHere;
	public bool BillyHere;
	public bool GuestHere;

	// Use this for initialization
	void Start () {
		BrettHere = false;
		BillyHere = false;
		GuestHere = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (BillyHere && BrettHere && GuestHere) {
			//beat the level
			if (Application.loadedLevel != 2)
				Application.LoadLevel (Application.loadedLevel+1);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			ItemBase item = other.gameObject.GetComponent<ItemCarrier>().carriedItem;
			if(item != null && item.itemName == "Guest") {
				GuestHere = true;
			}
			if(other.gameObject.name == "Billy") {
				BillyHere = true;
			}
			else if (other.gameObject.name == "Brett") {
				BrettHere = true;
			}
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Player") {
			ItemBase item = other.gameObject.GetComponent<ItemCarrier>().carriedItem;
			if(item != null && item.itemName == "Guest") {
				GuestHere = false;
			}
			if(other.gameObject.name == "Billy") {
				BillyHere = false;
			}
			else if (other.gameObject.name == "Brett") {
				BrettHere = false;
			}
		}
	}
}
