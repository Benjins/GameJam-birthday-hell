using UnityEngine;
using System.Collections;

public class ItemBase : MonoBehaviour {

	public float throwForce = 100.0f;
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
		transform.parent = pickedUpBy.transform;
		pickedUpBy.carriedItem = this;
	}

	public virtual void OnDrop(){
		carrier.carriedItem = null;
		carrier = null;
	}

	public virtual void OnUse(){

	}

	public virtual void OnThrow(){
		carrier.carriedItem = null;
		carrier = null;
		transform.parent = null;
		thrown = true;

		if(rigidbody){
			rigidbody.AddForce(new Vector3(0.8f, 0.6f, 0.0f) * throwForce);
		}
		//Actually throw the item with physics.
	}

	protected virtual void OnCollisionEnter(Collision col){
		if(thrown && col.collider.tag == "Player"){
			thrown = false;
			OnPickup(col.collider.GetComponent<ItemCarrier>());
		}
		else if(thrown && col.collider.tag == "Terrain"){
			thrown = false;
		}
	}
}
