using UnityEngine;
using System.Collections;

public class IndivPlat : MonoBehaviour {

	public GameObject Billy;
	public GameObject Brett;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void onMove () {
		if (Billy != null) {
			Billy.transform.position = this.transform.position - new Vector3(0, -1.6f, 0);
		}
		if (Brett != null) {
			Brett.transform.position = this.transform.position - new Vector3(0, -1.6f, 0);
		}
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.name == "Billy") {
			Billy = other.gameObject;
			Debug.Log ("got billy");
		}
		else if (other.gameObject.name == "Brett") {
			Brett = other.gameObject;
			Debug.Log ("got brett");
		}
	}
	void OnCollisionExit(Collision other) {
		if (other.gameObject.name == "Billy") {
			Billy = null;
			Debug.Log ("lost billy");
		}
		else if (other.gameObject.name == "Brett") {
			Brett = null;
			Debug.Log ("lost brett");
		}
	}
}
