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
				Explode();
			}
		}
	}

	public override void OnDrop(){
		base.OnDrop();
		dropped = true;
	}

	public override void OnUse(){
		OnDrop();
	}

	public override void OnPickup (ItemCarrier pickedUpBy){
		base.OnPickup (pickedUpBy);
		dropped = false;
	}

	protected override void CarryUpdate(){
		timeSinceFuseStart = 0.0f;
	}

	protected override void OnCollisionEnter(Collision col){
		if(thrown && col.collider.tag == "Player"){
			thrown = false;
			OnPickup(col.collider.GetComponent<ItemCarrier>());
		}
		else if(thrown && col.collider.tag == "Terrain"){
			Explode();
		}
	}

	protected void Explode(){
		int explodeCount = 0;
		foreach(Collider col in Physics.OverlapSphere(transform.position, explosionRadius)){
			//col.renderer.material.color = Color.red;
			if(col.tag != "Player"){
				//col.renderer.material.color = Color.red;
				TileBase tile = col.gameObject.GetComponent<TileBase>();
				if(tile != null){
					//tile.renderer.material.color = Color.red;
					tile.OnExplode(transform.position);
					explodeCount++;
				}
			}
		}

		Debug.Log("Explosion count: " + explodeCount);

		Destroy(gameObject);
	}
}
