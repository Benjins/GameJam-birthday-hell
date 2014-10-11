using UnityEngine;
using System.Collections;

public class ItemBase : MonoBehaviour {

	public string itemName = "Item";
	public bool thrown = false;

	//TO-DO: Chagne type to character controller script
	GameObject carrier = null;

	// Use this for initialization
	void Start () {
	
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

	public virtual void OnPickup(GameObject pickedUpBy){
		carrier = pickedUpBy;
	}

	public virtual void OnDrop(){
		carrier = null;
	}

	public virtual void OnUse(){

	}

	public virtual void OnThrow(){
		carrier = null;
		thrown = true;
	}

	protected virtual void OnCollisonEnter(Collision col){
		if(thrown && col.collider.tag == "Player"){
			//Player picks up item
		}
		else if(thrown && col.collider.tag == "Terrain"){
			thrown = false;
		}
	}
}
