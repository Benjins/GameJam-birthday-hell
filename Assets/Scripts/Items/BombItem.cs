using UnityEngine;
using System.Collections;

public class BombItem : ItemBase {

	public float fuseTime = 2.0f;
	public float explosionRadius = 3.0f;

	private bool dropped = false;
	private float timeSinceFuseStart = 0.0f;

	protected override void GroundUpdate(){
		if(dropped){
			timeSinceFuseStart += Time.deltaTime;
			if(timeSinceFuseStart >= fuseTime){
				Debug.Log("Explode 1");
				Explode();
			}
		}
	}

	public override void OnDrop(){
		base.OnDrop();
		dropped = true;
	}

	public override void OnPickup (ItemCarrier pickedUpBy){
		base.OnPickup (pickedUpBy);
		dropped = false;
	}

	protected override void CarryUpdate(){
		timeSinceFuseStart = 0.0f;
	}

	protected override void OnCollisonEnter(Collision col){
		base.OnCollisonEnter(col);

		if(thrown && col.collider.tag == "Terrain"){
			Debug.Log("Explode 2");
			Explode();
		}
	}

	protected void Explode(){
		foreach(Collider col in Physics.OverlapSphere(transform.position,explosionRadius)){
			if(col.tag == "Terrain" && col.gameObject != gameObject){
				TileBase tile = col.gameObject.GetComponent<TileBase>();
				if(tile != null){
					tile.OnExplode(transform.position);
				}
				else{
					Debug.Log(col.gameObject.name);
					Debug.LogError("There is an object marked with tag Terrain without a TileBase component.", collider.gameObject);
				}
			}
		}

		Destroy(gameObject);
	}
}
