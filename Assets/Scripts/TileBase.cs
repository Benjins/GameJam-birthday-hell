using UnityEngine;
using System.Collections;

public class TileBase : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter(Collision col){
		if(col.collider.tag == "Player"){
			OnWalk(col.collider.gameObject);
		}
	}

	protected virtual void OnWalk(GameObject walker){

	}

	public virtual void OnExplode(Vector3 explosionCenter){
		Destroy(gameObject);
	}
}
