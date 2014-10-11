using UnityEngine;
using System.Collections;

public class ItemBase : MonoBehaviour {

	public bool useGravity = true;
	public string itemName = "Item";
	public bool thrown = false;

	//TO-DO: Chagne type to character controller script
	ItemCarrier carrier = null;

	// Use this for initialization
	void Start () {
		if(rigidbody != null){
			rigidbody.useGravity = useGravity;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(carrier == null){
			GroundUpdate();
		}
		else{
			CarryUpdate();
		}
	}

	protected virtual void GroundUpdate(){

	}

	protected virtual void CarryUpdate(){

	}

	public virtual void OnPickup(ItemCarrier pickedUpBy){
		carrier = pickedUpBy;
		pickedUpBy.carriedItem = this;
	}

	public virtual void OnDrop(){
		carrier = null;
	}

	public virtual void OnUse(){

	}

	public virtual void OnThrow(){
		carrier = null;
		carrier.carriedItem = null;
		thrown = true;

		//Actually throw the item with physics.
	}

	protected virtual void OnCollisonEnter(Collision col){
		if(thrown && col.collider.tag == "Player"){
			thrown = false;
			OnPickup(col.collider.GetComponent<ItemCarrier>());
		}
		else if(thrown && col.collider.tag == "Terrain"){
			thrown = false;
		}
	}
}
