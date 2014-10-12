using UnityEngine;
using System.Collections;

public class MovingWall : MonoBehaviour {
	
	public Vector3 pos1;

	public Vector3 pos2;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnSwitched(bool active) {
		if (active) {
			this.transform.position = pos1;
		} 
		else {
			this.transform.position = pos2;
		}
	}
}
