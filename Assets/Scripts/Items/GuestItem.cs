using UnityEngine;
using System.Collections;

public class GuestItem : ItemBase {

	bool pickedUp;
	float ystart;
	float falldist;

	// Use this for initialization
	void Start () {
		pickedUp = false;
		ystart = this.transform.position.y;
		falldist = 3;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void OnPickup(ItemCarrier pickedUpBy) {
		base.OnPickup (pickedUpBy);
		pickedUp = true;
	}

	protected override void OnCollisionEnter(Collision other) {
		base.OnCollisionEnter (other);
		if (other.gameObject.tag != "Player" && other.gameObject.tag != "Rope" && pickedUp && carrier == null) {
			Application.LoadLevel (Application.loadedLevel);
		} 
		if (carrier == null && other.gameObject.tag == "Terrain" && other.gameObject.transform.position.y < ystart - falldist) {
			Application.LoadLevel (Application.loadedLevel);
		}
	}
	
}
