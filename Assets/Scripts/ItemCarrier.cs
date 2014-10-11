using UnityEngine;
using System.Collections;

public class ItemCarrier : MonoBehaviour {

	public float pickUpRadius = 0.5f;

	[HideInInspector]
	public ItemBase carriedItem = null;

	void Update(){
		//Throw
		if(Input.GetKeyDown(KeyCode.I)){
			carriedItem.OnThrow();
		}

		//Pick up
		if(Input.GetKeyDown(KeyCode.U)){
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
