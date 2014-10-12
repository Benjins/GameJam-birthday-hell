using UnityEngine;
using System.Collections;

public class ItemCarrier : MonoBehaviour {

	public float pickUpRadius = 0.5f;
	//[HideInInspector]
	public ItemBase carriedItem = null;
	CameraScript cameraScript;

	Transform itemLocation;

	void Start(){
		itemLocation = transform.FindChild("Item Location");
		cameraScript = Camera.main.GetComponent<CameraScript>();
	}

	void Update(){
		if(carriedItem != null){
			carriedItem.transform.localPosition = itemLocation.localPosition;
		}

		if( (gameObject == cameraScript.Billy) ^ (CameraScript.charFollowing == "Billy")){
			return;
		}

		//Throw
		if(Input.GetKeyDown(KeyCode.I)){
			if(carriedItem != null){
				carriedItem.OnThrow();
			}
		}

//		if(Input.GetKeyDown(KeyCode.U)){
//			if(carriedItem != null){
//				carriedItem.OnUse();
//			}
//		}

		//Pick up
		if(Input.GetKeyDown(KeyCode.U)){
			//Drop the item we have
			if(carriedItem != null){
				carriedItem.OnDrop();
			}
			else{
				//Look for an item on the gorund to pick up
				foreach(Collider col in Physics.OverlapSphere(transform.position, pickUpRadius)){
					if(col.tag == "Item"){
						ItemBase item = col.GetComponent<ItemBase>();
						if(item != null){
							item.OnPickup(this);
							break;
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
