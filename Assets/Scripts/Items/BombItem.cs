using UnityEngine;
using System.Collections;

public class BombItem : ItemBase {

	public float fuseTime = 2.0f;
	public float explosionRadius = 3.0f;

	private float timeSinceFuseStart = 0.0f;

	protected override void GroundUpdate(){
		timeSinceFuseStart += Time.deltaTime;
		if(timeSinceFuseStart < fuseTime){
			Explode();
		}
	}

	protected override void CarryUpdate(){
		timeSinceFuseStart = 0.0f;
	}

	protected override void OnCollisonEnter(Collision col){
		if(thrown && col.collider.tag == "Player"){
			thrown = false;
			//Player picks up item
		}
		else if(thrown && col.collider.tag == "Terrain"){
			thrown = false;
			Explode();
		}
	}

	protected void Explode(){
		foreach(Collider col in Physics.OverlapSphere(transform.position,explosionRadius)){
			if(col.tag == "Terrain"){
				TileBase tile = collider.GetComponent<TileBase>();
				if(tile != null){
					tile.OnExplode(transform.position);
				}
				else{
					Debug.LogError("There is an object markes with tag Terrain without a TileBase component.", collider.gameObject);
				}
			}
		}
	}
}
