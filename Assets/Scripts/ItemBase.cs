using UnityEngine;
using System.Collections;

public class ItemBase : MonoBehaviour {

	public string itemName = "Item";

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
	}
}
