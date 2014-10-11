using UnityEngine;
using System.Collections;

public class ItemCarrier : MonoBehaviour {

	public float pickUpRadius = 0.5f;
	//[HideInInspector]
	public ItemBase carriedItem = null;

	Transform itemLocation;

	void Start(){
		itemLocation = transform.FindChild("Item Location");
	}

	void Update(){
		if(carriedItem != null){
			carriedItem.transform.localPosition = itemLocation.localPosition;
		}

		//Throw
		if(Input.GetKeyDown(KeyCode.I)){
			carriedItem.OnThrow();
		}

		if(Input.GetKeyDown(KeyCode.O)){
			carriedItem.OnUse();
		}

		//Pick up
		if(Input.GetKeyDown(KeyCode.P)){
			//Drop the item we have
			if(carriedItem != null){
				carriedItem.OnDrop();
			}
			else{
				Debug.Log("Trying to pick up item.");
				//Look for an item on the gorund to pick up
				foreach(Collider col in Physics.OverlapSphere(transform.position, pickUpRadius)){
					if(col.tag == "Item"){
						ItemBase item = col.GetComponent<ItemBase>();
						if(item != null){
							item.OnPickup(this);
						}
						else{
							Debug.LogError("There's an object tagged as an item without an ItemBase component.", col.gameObject);
						}
					}
				}
			}
		}
	}
}
